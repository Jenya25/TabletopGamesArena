using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TabletopGamesArena.Core
{
    internal static class Utils
    {
        internal static int ThGetInt(this object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
            {
                bool isInt = int.TryParse(value.ToString(), out int res);
                if (isInt)
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }

        internal static string ThGetSHA256_hash(this string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        internal static string ThGetTrimedString(this object value)
        {
            string result = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = string.Empty;
            }
            else
            {
                result = value.ToString().Trim();
            }
            return result;
        }

    }
}
