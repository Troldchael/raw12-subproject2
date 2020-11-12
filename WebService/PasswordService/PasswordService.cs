using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;

namespace WebService.PasswordService
{
    public class PasswordService
    {
        private static RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
        public static string HashPassword(string password, string salt, int size)
        {
            var hash = KeyDerivation.Pbkdf2(password,
                Encoding.UTF8.GetBytes(salt),
                KeyDerivationPrf.HMACSHA256, 10000, size);

            return Convert.ToBase64String(hash); 
        }

        public static string GenerateSalt(int size)
        {
            var buffer = new byte[size];
            _rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
    }
}