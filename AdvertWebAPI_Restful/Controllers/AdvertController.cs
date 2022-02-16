using AdvertWebAPI_Restful.Data;
using AdvertWebAPI_Restful.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AdvertWebAPI_Restful.Controllers
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdvertController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AdvertDTO> Get()
        {
            return _context.Adverts.Select(e => new AdvertDTO
            {
                Id = e.Id,
                AdvertTitle = e.AdvertTitle,
                AdvertText = e.AdvertText,
                DateAdded = e.DateAdded
            });
        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult GetSingle(int id)
        {
            var advert = _context.Adverts.Where(e=>e.Id == id).Select(e=> new AdvertNewDTO
            {
                Id = e.Id,
                AdvertTitle = e.AdvertTitle,
                AdvertText = e.AdvertText,
                DateAdded = DateTime.Now,
            }).FirstOrDefault();
            if (advert == null)
                return NotFound();
            return Ok(advert);
        }
        [HttpPost]

        public ActionResult<AdvertDTO> Create(AdvertNewDTO model)
        {
            var advert = new Advert
            {
                AdvertTitle = model.AdvertTitle,
                AdvertText = model.AdvertText,
                DateAdded= DateTime.Now
            };
            _context.Adverts.Add(advert);
            _context.SaveChanges();
            int id = advert.Id;
            var obj = new AdvertDTO();
            obj.AdvertTitle = model.AdvertTitle;
            obj.AdvertText = model.AdvertText;
            obj.DateAdded = model.DateAdded;

            return CreatedAtAction(nameof(GetSingle),new { id = id }, obj);
        }
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] AdvertDTO model)
        {
            var advert = _context.Adverts.FirstOrDefault(e=>e.Id == id);
            if (advert == null) return NotFound();
            advert.AdvertTitle = model.AdvertTitle;
            advert.AdvertText = model.AdvertText;
            advert.DateAdded = model.DateAdded;
            _context.SaveChanges();
            return Ok(advert);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Advert advert = _context.Adverts.Where(x => x.Id == id).FirstOrDefault();
            if (advert == null)
            {
                return NotFound();
            }
            _context.Adverts.Remove(advert);
            _context.SaveChanges();
            return Ok(advert);
        }
    }
}
