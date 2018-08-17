using System.Web.Mvc;

namespace WebAp.Controllers
{
    public class BaseController : Controller
    {
        public int pageSize;
        public BaseController()
        {
            string _pageSize = System.Configuration.ConfigurationManager.AppSettings["pageSize"] ?? "10";
            int.TryParse(_pageSize, out pageSize);
           
        }

    }
}