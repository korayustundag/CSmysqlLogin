using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSmysqlLogin
{
    public static class Settings
    {
        // MySQL Connection String
        public static readonly string ConnectionString = "server=localhost;user=root;database=mydatabase;port=3306;password=****";

        // Login Control
        public static bool logined { get; set; }

        // User ID from DB
        public static int id { get; set; }


        // Username from DB
        public static string username { get; set; }

        // SHA256 hash creator for Passwords
        public static string SHA256Hash(string content)
        {
            SHA256 sh = new SHA256CryptoServiceProvider();
            sh.ComputeHash(UTF8Encoding.UTF8.GetBytes(content));
            byte[] result = sh.Hash;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
