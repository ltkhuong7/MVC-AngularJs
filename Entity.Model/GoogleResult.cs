using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class GoogleResult
    {
        public string Keyword { get; set; }
        public string SearchEngineSite { get; set; }
        public string TargetSite { get; set; }
        public int NoFirstResult { get; set; }
        public string Result { get; set; }
        public DateTime DateSearch { get; set; }
        public int TotalResultCount
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Result))
                    return 0;

                if (string.Equals(Result, "0"))
                    return 0;

                var num = Result.Split(',').Length;
                return num;
            }
        }
    }
}
