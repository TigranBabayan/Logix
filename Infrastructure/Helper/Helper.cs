using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.Helper
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

        public static string AddressFormating(this string address)
        {
            StringBuilder formatedAddress = new StringBuilder();

            if(!string.IsNullOrWhiteSpace(address))
            {
                address = Regex.Replace(address," {2,}"," ");
                formatedAddress.Append(address.ToUpper());
                formatedAddress.Replace(".", " ");
                formatedAddress.Replace("AVENUES", "AVES");
                formatedAddress.Replace("AVENUE", "AVE");
                formatedAddress.Replace("BOULVARDS", "BLVDS");
                formatedAddress.Replace("BOULVARD", "BLVD");
                formatedAddress.Replace("STREETS", "STS");
                formatedAddress.Replace("STREET", "ST");
                formatedAddress.Replace("NO", " ");
                formatedAddress.Replace("APARTAMENTS", "APTS");
                formatedAddress.Replace("APARTAMENT", "APT");
                formatedAddress.Replace("ROAD", "RD");
                formatedAddress.Replace("ROADS", "RDS");
                formatedAddress.Replace("NUMBER", "");
                formatedAddress.Replace("#", "");

                return formatedAddress.ToString();
            }
            return string.Empty;
        }

    }
}
