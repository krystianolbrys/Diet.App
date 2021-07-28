using Diet.App.Api.Security.Services.Architecture;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Diet.App.Api.Service.Controllers
{
    [Produces("application/json")]
    public class SecurityController : Controller
    {
        private readonly ITokenService _tokenService;

        public SecurityController(ITokenService tokenService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [Route("api/security/getToken/{login}")]
        [HttpGet]
        public IActionResult GetToken(string login)
        {
            var userModel = new UserViewModel { Login = login, Id = Guid.NewGuid() };

            var json = JsonConvert.SerializeObject(userModel);

            var token = new TokenViewModel
            {
                Token = _tokenService.CreateToken(json)
            };

            return Ok(token);
        }

        [Route("api/security/readToken")]
        [HttpGet]
        public IActionResult ReadToken()
        {
            Request.Headers.TryGetValue("token", out var token);

            var isValid = _tokenService.CheckToken(token);

            if (!isValid)
            {
                return BadRequest();
            }

            var json = _tokenService.GetDataFromValidToken(token);

            return Ok(json);
        }
    }

    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
    }

    public class TokenViewModel
    {
        public string Token { get; set; }
    }
}
