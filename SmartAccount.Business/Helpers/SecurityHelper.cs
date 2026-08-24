using System;
using System.Security.Cryptography;
using System.Text;

namespace SmartAccount.Business.Helpers
{
    public static class SecurityHelper
    {
        private const int SaltSize = 32;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        public static string GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string hash, string salt)
        {
            string newHash = HashPassword(password, salt);
            return hash == newHash;
        }
    }
}
