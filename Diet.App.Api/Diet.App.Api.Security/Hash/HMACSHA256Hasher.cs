using Diet.App.Api.Security.Hash.Architecture;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Diet.App.Api.Security.Hash
{
    public class HMACSHA256Hasher : IHashProcessor
    {
        private readonly string _key;

        public HMACSHA256Hasher(string key)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));
        }

        public byte[] Compute(string dataToCompute)
        {
            var keyBytes = Encoding.ASCII.GetBytes(_key);
            var dataBytes = Encoding.ASCII.GetBytes(dataToCompute);

            using(var generator = new HMACSHA256(keyBytes))
            {
                var computedHashBytes = generator.ComputeHash(dataBytes);
                return computedHashBytes;
            }
        }

        public string ComputeToBase64String(string dataToCompute)
        {
            var keyBytes = Encoding.ASCII.GetBytes(_key);
            var dataBytes = Encoding.ASCII.GetBytes(dataToCompute);

            using (var generator = new HMACSHA256(keyBytes))
            {
                var computedHashBytes = generator.ComputeHash(dataBytes);
                return Convert.ToBase64String(computedHashBytes);
            }
        }
    }
}
