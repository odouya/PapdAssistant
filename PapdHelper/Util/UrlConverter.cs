using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Tool
{
    public class UrlConverter
    {
        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }
            return (sb.ToString());
        }

        public static string UrlEncode2(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(Convert.ToString(byStr[i], 16));
            }
            return (sb.ToString());
        }

        public static string UrlDecode(string str)
        {
            char[] cr = str.ToCharArray();

            byte[] byStr = new byte[cr.Length / 2];

            int j = 0;
            for (int i = 0; i < byStr.Length; i++)
            {
                byStr[i] = byte.Parse(cr[j] + "" + cr[j + 1], System.Globalization.NumberStyles.HexNumber);
                j = j + 2;
            }
            str = System.Text.Encoding.UTF8.GetString(byStr);

            return (str);
        }
    }
}
