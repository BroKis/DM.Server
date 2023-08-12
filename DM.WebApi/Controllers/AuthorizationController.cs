using DM.API.ModelsDTO;
using DM.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DM.API.Controllers;
/// <summary>
/// Controller for Web Api
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
   
   private IAuthorizationService _service;

   public AuthController(IAuthorizationService service)
   {
      _service = service;
   }

   /// <summary>
   /// Methods which implements creating session
   /// </summary>
   /// <param name="auth">Class with login and password</param>
   /// <returns>It returns JSON class format session </returns>
   [HttpPost]
   public async Task<IResult> DataForAuth(AuthModel auth)
   {
      UsersDTO user = await _service.UsersGetByAuth(auth);
      if (user is null)
      {
         return Results.Unauthorized();
      }
      var resp =await _service.SessionCreate(user);
      return Results.Json(resp);
   }
/// <summary>
/// Method which gets from datatbase user by token
/// </summary>
/// <param name="token"> JWT-token</param>
/// <returns>It returns JSON class format user</returns>
   [HttpGet("{token}")]
   public async Task<IResult> UserByToken(string token)
   {
      object user = await _service.UsersGetByToken(token);
      if (user is null)
      {
         return Results.Unauthorized();
      }

      return Results.Json(user);
   }

   
}