using Model;
using PagedList;
using Services;
using Services.Interface;
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

        public ActionResult detail(int id)
        {
            var _data = _employeeService.getInfo(id);
            return View(_data);
        }


        #region JsonResult

        public ActionResult searchList(Employees data, int page = 1)
        {
            var _list = _employeeService.getList(data);
            int _currentPage = page < 1 ? 1 : page;
            var pageResult = _list.ToPagedList(_currentPage, this.pageSize);


            return PartialView("_SearchResult", pageResult);

        }

        public ActionResult del(int id)
        {
            var _result = _employeeService.del(id);
            return Json(_result);
        }

        public ActionResult update(Employees data)
        {
            var _result = _employeeService.update(data);
            return Json(_result);
        }



        #endregion
    }
}