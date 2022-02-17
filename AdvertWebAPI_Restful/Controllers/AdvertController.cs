using AdvertWebAPI_Restful.Data;
using AdvertWebAPI_Restful.Model;
using AdvertWebAPI_Restful.Services.AdvertService;
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
        private readonly IAdvertService _advertService;

        public AdvertController(ApplicationDbContext context, IAdvertService advertService)
        {
            _context = context;
            _advertService = advertService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var adverts = _advertService.List();
            if (adverts == null)
            {
                return NotFound("Inga annonser hittades!");
            }
            return Ok(adverts);
        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult GetSingle(int id)
        { 
            var advert = _advertService.Get(id);
            if (advert == null)
            {
                return NotFound("Denna annons kan ej hittas");
            }
            return Ok(advert);
        }
        [HttpPost]

        public ActionResult<AdvertDTO> Create(AdvertNewDTO model)
        {
            var result = _advertService.Create(model);
            return Ok(result);

        }
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] AdvertDTO model)
        {
            var advert = _advertService.Update(id, model);
            if (advert == null) return NotFound("Annonsen kan inte hittas!");
            return Ok(advert);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var advert = _advertService.Delete(id);
            if (advert == null)
            {
                return NotFound("Den här annonsen finns inte!");
            }
            return Ok(advert);
        }
    }
}
