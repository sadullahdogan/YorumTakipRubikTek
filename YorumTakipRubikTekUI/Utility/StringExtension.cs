using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace YorumTakipRubikTekUI.Utility
{
    public static class StringExtension 
    {
        public static string YasakKontrol(this string text, List<YasakliKelime> kelimelist)
        {
            foreach (var item in kelimelist)
            {
                string replacement = string.Empty;
                for (int i = 0; i < item.Kelime.Length; i++)
                {
                    replacement += '*';
                }
                text = Regex.Replace(text, item.Kelime, replacement, RegexOptions.IgnoreCase);

            }
            return text;
        }
    }
}