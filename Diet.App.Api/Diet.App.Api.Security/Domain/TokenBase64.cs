using System;

namespace Diet.App.Api.Security.Domain
{
    public class TokenBase64
    {
        public string Data { get; private set; }
        public string Hash { get; private set; }

        public TokenBase64(string data, string hash)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            Hash = hash ?? throw new ArgumentNullException(nameof(hash));
        }
    }

    public class TokentSemanticValidator
    {
        public static bool Validate(string token, int tokenSegments, char delimiter)
        {
            if (string.IsNullOrWhiteSpace(token) || token.Length > 1000)
            {
                return false;
            }

            return token.Split(delimiter).Length == tokenSegments;
        }
    }
}
