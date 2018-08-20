using System.Web.Mvc;

namespace WebAp.Controllers
{
    public class HomeController :BaseController
    {

        public ActionResult error()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }               

    }
}