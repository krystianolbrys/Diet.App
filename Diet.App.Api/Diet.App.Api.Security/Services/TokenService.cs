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
            if (!TokentSemanticValidator.Validate(token, 2, Signs.Dot))
            {
                return false;
            }

            var tokenBase64 = CreateTokenBase64(token);

            return 
                _hashProcessor.ComputeToBase64String(
                    ConvertBase64ToString(tokenBase64.Data)) == tokenBase64.Hash;
        }

        public string CreateToken(string data)
        {
            var hash = _hashProcessor.ComputeToBase64String(data);

            var base64data = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));

            var token = String.Concat(base64data, Signs.Dot, hash);
            return token;
        }

        public string GetDataFromValidToken(string token) =>
            ConvertBase64ToString(CreateTokenBase64(token).Data);

        private TokenBase64 CreateTokenBase64(string token)
        {
            var tokenSegments = token.Split(Signs.Dot);

            return new TokenBase64(tokenSegments[0], tokenSegments[1]);
        }

        private string ConvertBase64ToString(string base64String)
        {
            var base64Bytes = Convert.FromBase64String(base64String);

            var stringFromBytes = Encoding.UTF8.GetString(base64Bytes);

            return stringFromBytes;
        }
    }
}
