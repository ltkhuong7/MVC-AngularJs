using DataAccess.Provider.Contract;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.Provider
{
    public class HtmlStringGoogleProvider : IHtmlStringProvider
    {
        public HtmlStringGoogleProvider() {

        }

        public string GetHtmlString(string keywork, string searchEngineUrl, int start)
        {
            if (string.IsNullOrWhiteSpace(keywork))
                throw new ArgumentException("keyword is required");

            if (string.IsNullOrWhiteSpace(searchEngineUrl))
                throw new ArgumentException("Search engine base url is required");

            //https://www.google.com.au/search?q=online+title+search&start=13 //page 2
            var retval = string.Empty;
            var keywordString = HttpUtility.UrlEncode(keywork);
            using (var webClient = new WebClient())
            {
                NameValueCollection nameValueCollection = new NameValueCollection();
                nameValueCollection.Add("q", keywordString);
                nameValueCollection.Add("start", string.Format("{0}", start));

                webClient.QueryString.Add(nameValueCollection);
                retval = webClient.DownloadString(searchEngineUrl);
            }

            return retval;
        }
    }
}
