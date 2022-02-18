using AdvertWebAPI_Restful.Data;
using AdvertWebAPI_Restful.Model;
using AdvertWebAPI_Restful.Models;
using AdvertWebAPI_Restful.Services;
using AdvertWebAPI_Restful.Services.AdvertService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AdvertWebAPI_Restful.Controllers
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAdvertService _advertService;
        private readonly IUserService _userService;

        public AdvertController(IAdvertService advertService, IUserService userService, IConfiguration configuration)
        {
            _advertService = advertService;
            _userService = userService;
            _configuration = configuration;
        }

        //[HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Standard")]
        //public IActionResult GetAll()
        //{
        //    var adverts = _advertService.List();
        //    if (adverts == null)
        //    {
        //        return NotFound("Inga annonser hittades!");
        //    }
        //    return Ok(adverts);
        //}

        //[HttpGet]
        //[Route("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Standard")]
        //public IActionResult GetSingle(int id)
        //{
        //    var advert = _advertService.Get(id);
        //    if (advert == null)
        //    {
        //        return NotFound("Denna annons kan ej hittas");
        //    }
        //    return Ok(advert);
        //}
        //[HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        //public ActionResult<AdvertDTO> Create(AdvertNewDTO model)
        //{
        //    var result = _advertService.Create(model);
        //    return Ok(result);

        //}
        //[HttpPut("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        //public IActionResult Put(int id, [FromBody] AdvertDTO model)
        //{
        //    var advert = _advertService.Update(id, model);
        //    if (advert == null) return NotFound("Annonsen kan inte hittas!");
        //    return Ok(advert);
        //}
        //[HttpDelete("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        //public IActionResult Delete(int id)
        //{
        //    var advert = _advertService.Delete(id);
        //    if (advert == null)
        //    {
        //        return NotFound("Den här annonsen finns inte!");
        //    }
        //    return Ok(advert);
        //}
    }
}
