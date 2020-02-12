using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace YorumTakipRubikTekUI.Utility
{
    public class RastgeleSifre
    {
        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(2, true));
            builder.Append(new Random().Next(100,999));
            builder.Append(RandomString(3, false));
            return builder.ToString();
        }
    }
}