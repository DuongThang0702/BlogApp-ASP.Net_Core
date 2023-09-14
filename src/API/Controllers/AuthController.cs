using AutoMapper;
using Core.Db.Entities;
using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto payload) {
            if (payload == null)
            {
                return BadRequest();
            }
            var response = await _authServices.Register(payload);

            return response.Succeeded ?  Ok(response) : Unauthorized();
        }
    }
}
