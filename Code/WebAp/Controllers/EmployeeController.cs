using Model;
using Services;
using System.Web.Mvc;

namespace WebAp.Controllers
{
    public class EmployeeController : JsonNetController
    {
        private IEmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeesService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getEmployees(PageInfo page, Employees data)
        {

            var _result = _employeeService.getEmployees(page, data);
            return Json(new JsonResult() { Data = _result },JsonRequestBehavior.AllowGet);
        }

    }
}