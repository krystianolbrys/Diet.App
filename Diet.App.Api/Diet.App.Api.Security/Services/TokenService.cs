using Diet.App.Api.Security.Domain;
using Diet.App.Api.Security.Hash.Architecture;
using Diet.App.Api.Security.Services.Architecture;
using System;
using System.Text;

namespace Diet.App.Api.Security.Services
{
    public class TokenService : ITokenService
    {
        private readonly IHashProcessor _hashProcessor;

        public TokenService(IHashProcessor hashProcessor)
        {
            _hashProcessor = hashProcessor ?? throw new ArgumentNullException(nameof(hashProcessor));
        }

        public bool CheckToken(string token)
        {
            // logic here
            return true;
        }

        public string CreateToken(string data)
        {
            var hash = _hashProcessor.ComputeToBase64String(data);

            var base64data = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));

            var token = String.Concat(base64data, Signs.Dot, hash);

            return token;
        }
    }
}
