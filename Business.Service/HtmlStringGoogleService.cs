using Business.Service.Contract;
using DataAccess.Provider.Contract;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Contract;

namespace Business.Service
{
    public class HtmlStringGoogleService : IHtmlStringService
    {
        private readonly IHtmlStringProvider _htmlStringProvider;
        private readonly IHtmlStringHelper _htmlHelper;
        public HtmlStringGoogleService(IHtmlStringProvider htmlStringProvider, IHtmlStringHelper htmlHelper)
        {
            _htmlStringProvider = htmlStringProvider;
            _htmlHelper = htmlHelper;
        }

        public GoogleResult Search(string keywork, string searchEngineUrl, string targetSite, int firstResults = 100)
        {
            var googleResult = new GoogleResult
            {
                Keyword = keywork,
                SearchEngineSite = "Google",
                TargetSite = targetSite,
                NoFirstResult = firstResults,
                Result = "0",
                DateSearch = DateTime.Now
            };

            var results = ParseCiteElement(keywork, searchEngineUrl, firstResults).ToList();

            if (results.Any())
            {
                googleResult.Result = _htmlHelper.FormatSearchResult(results, targetSite);
            }

            return googleResult;
        }
        
        public IList<string> ParseCiteElement(string keywork, string searchEngineUrl, int firstResults = 100)
        {
            if (string.IsNullOrWhiteSpace(keywork))
                throw new ArgumentException("keyword is required");

            if (string.IsNullOrWhiteSpace(searchEngineUrl))
                throw new ArgumentException("Search engine base url is required");

            if (firstResults <= 0)
                throw new ArgumentException("Minimum first result must be greater than zero");

            var loopNum = (int)Math.Ceiling(firstResults / 10.0);

            var listSites = new List<string>();
            for (var i = 0; i < loopNum; i++)
            {
                var start = i * 10;
                var htmlString = _htmlStringProvider.GetHtmlString(keywork, searchEngineUrl, start);

                if (string.IsNullOrWhiteSpace(htmlString))
                    continue;

                var result = _htmlHelper.ListCiteElement(htmlString);

                if (!result.Any())
                    continue;

                listSites.AddRange(_htmlHelper.ListCiteElement(htmlString));
            }

            if (listSites.Count > firstResults)
            {
                listSites = listSites.Take(firstResults).ToList();
            }

            return listSites;
        }
    }
}
