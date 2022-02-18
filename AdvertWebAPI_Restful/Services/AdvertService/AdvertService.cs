using AdvertWebAPI_Restful.Data;
using AdvertWebAPI_Restful.Model;
using Microsoft.AspNetCore.Mvc;

namespace AdvertWebAPI_Restful.Services.AdvertService
{
    public class AdvertService : IAdvertService
    {
        private readonly ApplicationDbContext _context;

        public AdvertService(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public Advert Create(AdvertNewDTO model)
        {
            var advert = new Advert
            {
                AdvertTitle = model.AdvertTitle,
                AdvertText = model.AdvertText,
                DateAdded = DateTime.Now
            };
            _context.Adverts.Add(advert);
            _context.SaveChanges();

            return advert;
        }
        public List<AdvertDTO> List()
        {
            return _context.Adverts.Select(e => new AdvertDTO
            {
                Id = e.Id,
                AdvertTitle = e.AdvertTitle,
                AdvertText = e.AdvertText,
                DateAdded= DateTime.Now
            }).ToList();
        }
        public Advert Get(int id)
        {
            return _context.Adverts.FirstOrDefault(e => e.Id == id);
        }
        public Advert Update(int id, [FromBody] AdvertDTO model)
        {
            var advert = _context.Adverts.First(e => e.Id == id);
            advert.Id = id;
            advert.AdvertTitle = model.AdvertTitle;
            advert.AdvertText = model.AdvertText;
            advert.DateAdded = model.DateAdded;
            _context.SaveChanges();
            return advert;
        }
        public IResult Delete(int id)
        {
            Advert advert = _context.Adverts.Where(e => e.Id == id).FirstOrDefault();
            if (advert == null)
            {
                return Results.NotFound("Denna annons redan finns inte!");
            }
            _context.Adverts.Remove(advert);
            _context.SaveChanges();
            return Results.Ok(advert);
        }
    }
}