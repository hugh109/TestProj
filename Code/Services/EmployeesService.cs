using Model;
using Repository;
using System;
using System.Collections.Generic;



namespace Services
{
    public class EmployeesService : IEmployeeService
    {
        private IEmployeesRepository _repository;
        public EmployeesService(IEmployeesRepository repository)
        {
            _repository = repository;
        }
        List<Employees> IEmployeeService.getEmployees(PageInfo page,Employees data)
        {
            var _result = _repository.getEmployees(data);

            return _result;
        }
    }
}
