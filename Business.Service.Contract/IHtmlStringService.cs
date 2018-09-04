using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Contract
{
    public interface IHtmlStringService
    {
        GoogleResult Search(string keywork, string searchEngineUrl, string targetSite, int firstResults = 100);
        IList<string> ParseCiteElement(string keywork, string searchEngineUrl, int firstResults = 100);
    }
}
