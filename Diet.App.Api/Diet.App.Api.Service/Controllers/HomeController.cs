using Diet.App.Api.Security.Hash;
using Diet.App.Api.Security.Hash.Architecture;
using Diet.App.Api.Security.Services.Architecture;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Diet.App.Api.Controllers
{
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private readonly ITokenService _tokenService;

        public HomeController(ITokenService tokenService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        public IActionResult Index()
        {
            var token = _tokenService.CreateToken("teścik");

            var ddd = _tokenService.CheckToken("dGXFm2Npaw==.eRJBQRjxsKT+xnZfF3Q9UFTriX7towIkl5A6wCalzBk=");



            return Ok(new { Token = token, Compred = ddd });
        }
    }
}