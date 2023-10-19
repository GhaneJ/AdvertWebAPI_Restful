namespace AdvertWebAPI_Restful.Controllers;

using AdvertWebAPI_Restful.Model;
using AdvertWebAPI_Restful.Services;
using AdvertWebAPI_Restful.Services.AdvertService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public ActionResult<AdvertDTO> Create(AdvertNewDTO model)
    {
        var result = _advertService.Create(model);
        return Ok(result);

    }

    [HttpPut("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public IActionResult Put(int id, [FromBody] AdvertDTO model)
    {
        var advert = _advertService.Get(id);
        if (advert != null)
        {
            _advertService.Update(id, model);
            return Ok(advert);
        }
        return NotFound("Annonsen kan inte hittas!");
    }

    [HttpPatch("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Standard")]
    public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Advert> patchDocument)
    {
        var advert = _advertService.Get(id);
        if (advert != null)
        {
            //_advertService.Patch(id, patchDocument);
            return NotFound();
        }
        patchDocument.ApplyTo(advert, ModelState);
        //return NoContent();
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var advert = _advertService.Get(id);
        if (advert != null)
        {
            _advertService.Delete(id);
            return Ok(advert);
        }
        return NotFound("Den här annonsen finns inte!");
    }
}
