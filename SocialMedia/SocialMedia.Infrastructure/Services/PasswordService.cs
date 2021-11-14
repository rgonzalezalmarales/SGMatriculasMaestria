using SocialMedia.Infrastructure.Interfaces;
using SocialMedia.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;

namespace SocialMedia.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions _passwordOptions;

        public PasswordService(IOptions<PasswordOptions> options)
        {
            _passwordOptions = options.Value;                
        }
        public bool Check(string hash, string password)
        {
            var parts = hash.Split('.');
            if (parts.Length != 3)
                throw new FormatException("Unexpected hash format");

            int iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            //10000.hmV1RB2yUVTJ7qJLv/b1Dg==.xk2vWBQc8HH8PPPP8tFGJHNcJHEkSW7xD8a7eCdiais=

            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations))
            {
                var keyToCheck = algorithm.GetBytes(_passwordOptions.KeySize);
                //using System.Linq; => SequenceEqual
                return keyToCheck.SequenceEqual(key);
            };
        }

        public string Hash(string password)
        {
            //PBKDF2 Implementation
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                _passwordOptions.SaltSize,
                _passwordOptions.Iterations)) 
            {
                //Cada vez que se llama a GetBytes genera un key diferente
                var key = Convert.ToBase64String(algorithm.GetBytes(_passwordOptions.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{_passwordOptions.Iterations}.{salt}.{key}";
            };
        }
    }
}
