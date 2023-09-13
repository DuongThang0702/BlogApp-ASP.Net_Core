using AutoMapper;
using Core.Db.Entities;
using Core.Dtos.auth;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authservices;
        private readonly IUserServices _userservices;
        private readonly IMapper _mapper;

        public AuthController(IAuthServices authservices, IUserServices userservices, IMapper mapper)
        {
            _authservices = authservices;
            _userservices = userservices;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterDto Payload)
        {
            if (Payload == null)
            {
                return BadRequest();
            }
            var user = await _userservices.FindOneByEmail(Payload.Email);
            if (user != null)
            {
                return BadRequest("Email has exsited!");
            }
            var response = await _authservices.Register(Payload);
            return response == 1 ? Ok(new { Message = "Register Successfully" }) : BadRequest("Something went wrong!");
        }

        [HttpPost]
        public async Task<ActionResult> Login()
        {
            return Ok();
        }
    }
}
