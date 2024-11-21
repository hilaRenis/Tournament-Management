using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL.Utils
{
    public static class PasswordHash
    {
        private const int SaltSize = 16;

        public static string GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
            Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

            using (var hasher = new SHA256Managed())
            {
                byte[] hashedBytes = hasher.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static bool VerifyPassword(string password, string salt, string hashedPassword)
        {
            string computedHash = HashPassword(password, salt);
            return string.Equals(computedHash, hashedPassword);
        }
    }
}
