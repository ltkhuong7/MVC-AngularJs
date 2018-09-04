using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Provider.Contract
{
    public interface IHtmlStringProvider
    {
        string GetHtmlString(string keywork, string searchEngineUrl, int start);
    }
}
