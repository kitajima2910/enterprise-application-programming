using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Lab5WebAPP.Helpers
{
    public class Help
    {
        public static class Password
        {
            private static string key = new Random().Next(1000).ToString();

            public static string Encryption(string key, string planText)
            {
                return null;
            }

            public static string Decryption(string key, string planText)
            {
                return null;
            }
        }
    }
}
