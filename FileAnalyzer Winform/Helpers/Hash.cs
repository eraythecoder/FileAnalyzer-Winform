using System.Security.Cryptography;
using System.Text;


namespace FileAnalyzer_Winform
{
    public static class Hash
    {
        public static string HashPassword(string password)
        {
            using (SHA256 key = SHA256.Create())
            {
                // Convert the password string into a byte array and compute the hash
                byte[] bytes = key.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array into a string representation (hexadecimal format)
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString(); // Return the hashed password as a string
            }
        }
    }
}
