using Model;
using Repository;
using System.Collections.Generic;



namespace Services
{
    public class EmployeesService : IEmployeeService
    {
        private IEmployeesRepository _repository;
        
        public EmployeesService()
        {
            _repository = new EmployeesRepository();
        }
        List<Employees> IEmployeeService.getEmployees(PageInfo page,Employees data)
        {
            var _result = _repository.getEmployees(data);

            return _result;
        }
    }
}
