using System.Security.Cryptography;

namespace ProjectDemoBackEND.Security.Hashing
{
    public static class HashingPassword
    {
        public static void CreatePassword(string password,  out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool checkPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computerdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for(int i = 0; i < computerdHash.Length; i++)
                {
                    if(computerdHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}