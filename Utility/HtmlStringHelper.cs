using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utility.Contract;

namespace Utility
{
    public class HtmlStringHelper : IHtmlStringHelper
    {
        public IList<string> ListCiteElement(string htmlString)
        {
            var retval = new List<string>();
            string pattern = "<cite.*?>(.*?)<\\/cite>";

            MatchCollection matches = Regex.Matches(htmlString, pattern);

            if (matches.Count > 0)
                foreach (Match m in matches)
                {
                    var item = Regex.Replace(m.Value, "<.*?>", string.Empty).ToLower();
                    retval.Add(item);
                }
            
            return retval;
        }

        public string FormatSearchResult(IList<string> listSites, string targetSite)
        {
            var result = string.Empty;

            if (!listSites.Any())
            {
                result = "0";
                return result;
            }
            
            for (var i = 0; i < listSites.Count; i++)
            {
                var item = listSites[i];
                if (item.Contains(targetSite))
                {
                    if(string.IsNullOrWhiteSpace(result))
                        result += string.Format("{0}", i + 1);
                    else
                        result += string.Format(", {0}", i + 1);
                }  
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = "0";
            }

            return result;
        }
    }
}
