namespace AdvertWebAPI_Restful.Data;

using AdvertWebAPI_Restful.Model;
using Microsoft.EntityFrameworkCore;

public class DataInitializer
{
    private readonly ApplicationDbContext _context;
    public DataInitializer(ApplicationDbContext context)
    {
        _context = context;
    }
    public void SeedData()
    {
        _context.Database.Migrate();
        SeedAdverts();
    }

    private void SeedAdverts()
    {
        createAdverts();
        _context.SaveChanges();
    }

    public Advert createAdverts()
    {
        var advert = new Advert();
        {
            if (!_context.Adverts.Any(e => e.AdvertTitle == "Mobiltelefon"))
                _context.Adverts.Add(new Advert { AdvertTitle = "Mobiltelefon", AdvertText = "En mobiltelefon med de originala utrustningarna!", DateAdded = DateTime.Now });
            if (!_context.Adverts.Any(e => e.AdvertTitle == "Dator"))
                _context.Adverts.Add(new Advert { AdvertTitle = "Dator", AdvertText = "En Bra dator i bra skick, billig och bärbar!", DateAdded = DateTime.Now });
            if (!_context.Adverts.Any(e => e.AdvertTitle == "Mugg"))
                _context.Adverts.Add(new Advert { AdvertTitle = "Mugg", AdvertText = "En fin mugg för dekoration!", DateAdded = DateTime.Now });
            if (!_context.Adverts.Any(e => e.AdvertTitle == "Bil"))
                _context.Adverts.Add(new Advert { AdvertTitle = "Bil", AdvertText = "En begagnad sportbil, hybrid och fin!", DateAdded = DateTime.Now });
            if (!_context.Adverts.Any(e => e.AdvertTitle == "Bandspelare"))
                _context.Adverts.Add(new Advert { AdvertTitle = "Bandspelare", AdvertText = "En bandspelare i ganska nysckick från slutet av 70-talet!", DateAdded = DateTime.Now });
            if (!_context.Adverts.Any(e => e.AdvertTitle == "Damsugare"))
                _context.Adverts.Add(new Advert { AdvertTitle = "Damsugare", AdvertText = "En kraftig Damsugare på rea", DateAdded = DateTime.Now });
            if (!_context.Adverts.Any(e => e.AdvertTitle == "Bord"))
                _context.Adverts.Add(new Advert { AdvertTitle = "Bord", AdvertText = "Ett gammalt brunt bord för dukning", DateAdded = DateTime.Now });
        };
        return advert;
    }
}