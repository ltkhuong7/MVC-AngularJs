using Business.Service;
using DataAccess.Provider;
using Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace InfoTrackTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Search(string keyword, string searchEngineSite, string targetSite, int noFirstResult = 100)
        {
            var googleProvider = new HtmlStringGoogleProvider();
            var htmlStringHelper = new HtmlStringHelper();
            var googleService = new HtmlStringGoogleService(googleProvider, htmlStringHelper);
            var searchEngineUrl = "https://www.google.com.au/search";
            var googleResult = googleService.Search(keyword, searchEngineUrl, targetSite, noFirstResult);
            return Json(googleResult, JsonRequestBehavior.AllowGet);
        }
    }
}