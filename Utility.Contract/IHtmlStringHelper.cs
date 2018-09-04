using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Contract
{
    public interface IHtmlStringHelper
    {
        IList<string> ListCiteElement(string htmlString);
        string FormatSearchResult(IList<string> listSites, string targetSite);
    }
}
