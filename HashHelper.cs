using System.Security.Cryptography;
using System.Text;

namespace Test.Helpers
{
    public static class HashHelper
    {
        // 🔐 Hash wachtwoord met SHA256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // ✅ Vergelijk input met opgeslagen hash
        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string hashedInput = HashPassword(inputPassword);
            return hashedInput == storedHash;
        }
    }
}
