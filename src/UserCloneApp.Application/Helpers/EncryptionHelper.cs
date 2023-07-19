using System.Security.Cryptography;
using System.Text;

namespace UserCloneApp.Application.Helpers
{
    public static class EncryptionHelper
    {
        private static readonly string SecretKey = "USER_CLONE_PRİVATE_KEY";

        public static string Encryption(string value)
        {
            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(SecretKey));

            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            byte[] hashBytes = hmac.ComputeHash(valueBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
