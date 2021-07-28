using System;
using System.Linq;

namespace Diet.App.Api.Security.Domain
{
    //separate Token and TOkenService
    public class Token
    {
        private readonly char _dotSign = '.';
        private readonly string _tokenString;
        public string Data { get; private set; }
        public string Hash { get; private set; }
        public bool IsValid { get; private set; }

        public Token(string tokenString)
        {
            if (string.IsNullOrWhiteSpace(tokenString))
            {
                throw new ArgumentNullException(nameof(tokenString));
            }

            _tokenString = tokenString;
        }

        private bool IsTokenValidSemanticaly()
        {
            var containsOnlyOneDot = _tokenString.Select(c => c == _dotSign).Count() == 1;

            if (!containsOnlyOneDot)
            {
                return false;
            }

            var dotPosition = _tokenString.IndexOf(_dotSign);

            var isDotPositionBetweenStartAndEnd = dotPosition > 0 && dotPosition < _tokenString.Length - 1;

            if (!isDotPositionBetweenStartAndEnd)
            {
                return false;
            }

            return true;
        }
    }
}
