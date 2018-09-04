using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class GoogleSearchModel
    {
        [Required(ErrorMessage = "Keyword is required")]
        public string Keyword { get; set; }
        [Required(ErrorMessage = "Search engine site is required")]
        public string SearchEngineSite { get; set; }
        [Required(ErrorMessage = "Target site is required")]
        public string TargetSite { get; set; }
        [Required(ErrorMessage = "Number of first result is required")]
        public int NoFirstResult { get; set; }
    }
}
