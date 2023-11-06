using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Persistence.Helper
{
    public static class Helper
    {
        public static string HashPasword(this string password)
        {
            string ret = "";
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.Unicode.GetBytes(password);
            bs = x.ComputeHash(bs);
            ret = "0x" + BitConverter.ToString(bs).Replace("-", "");
            return ret;
        }
    }
}
