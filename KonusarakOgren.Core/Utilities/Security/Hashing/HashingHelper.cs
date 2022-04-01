using System;
using System.Text;

namespace KonusarakOgren.Core.Utilities.Security.Hashing
{
    public static class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac512 = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac512.Key;
                passwordHash = hmac512.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac512 = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac512.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < passwordHash.Length - 1; i++)
                {
                    if (!computedHash[i].Equals(passwordHash[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}