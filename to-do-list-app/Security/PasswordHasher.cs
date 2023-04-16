namespace to_do_list_app.Security
{
    public class PasswordHasher
    {
        public static (string PasswordHash, string Salt) Hash(string password)
        {
            string salt = GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(password + salt);
            return (PasswordHash: hash, Salt: salt);
        }

        public static bool Verify(string password, string salt, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt, passwordHash);
        }

        public static string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
