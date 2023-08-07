using DarkmoonSession.API.ModelsDTO;
using DarkmoonSession.API.Service.Implementation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DarkmoonSession.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AutorizationController : ControllerBase
{
   private IAutorizationService _service;

   public AutorizationController(IAutorizationService service)
   {
      _service = service;
   }

   [HttpPost]
   
   public async Task<IResult> Auth(AuthModel auth)
   {
      var user = await _service.UsersGetByAuth(auth);
      if (user is null)
      {
         return Results.Unauthorized();
      }

      var resp =await _service.SessionCreate(user);
      return Results.Json(resp);
   }

   [HttpGet]
  
   public async Task<IResult> Get(string token)
   {
      var user = await _service.UsersGetByToken(token);
      if (user.Data is null)
      {
         return Results.Unauthorized();
      }

      return Results.Json(user);
   }
}