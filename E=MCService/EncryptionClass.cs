using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace E_MCService
{
    public class EncryptionClass
    {
        public static string HashPassword(string password)
        {
            string hashedPassword = string.Empty;
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256Managed hashString = new SHA256Managed();
            byte[] hashed = hashString.ComputeHash(bytes);
            foreach (byte b in hashed)
            {
                hashedPassword += string.Format("x2", b);
            }

            return hashedPassword;
        }
    }
}