using Spring.Context.Support;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nancal.Mvc.Demo.Controllers
{
    public class HomeController : Controller
    {
        private IDateWriter dateWriter = ContextRegistry.GetContext().GetObject<IDateWriter>("test2");
        public ActionResult Index()
        {
            var data = dateWriter.Query();
            var id = dateWriter.Save();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}