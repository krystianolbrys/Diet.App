using Diet.App.Api.Security.Hash;
using Diet.App.Api.Security.Hash.Architecture;
using Diet.App.Api.Security.Services.Architecture;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Diet.App.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITokenService _tokenService;

        public HomeController(ITokenService tokenService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        public IActionResult Index()
        {
            var hahed = _tokenService.CreateToken(Guid.NewGuid().ToString());

            return Ok(hahed);
        }
    }
}