using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonLibrary
{
    //by spadmin1
    public class LimitCharacters
    {
        public static string Limit(object Desc, int length)
        {
            StringBuilder strDesc = new StringBuilder();
            string str = StripHTML(Desc.ToString()).Replace("\r\n", string.Empty);
            strDesc.Insert(0, str.ToString());
            if (strDesc.Length > length)
                return strDesc.ToString().Substring(0, length) + "...";
            else return strDesc.ToString();
        }

        public static string StripHTML(string HTMLText)
        {
            Regex reg = new Regex(("<(.|\n)+?>"), RegexOptions.IgnoreCase);
            return reg.Replace(HTMLText, "");
        }
    }
}
