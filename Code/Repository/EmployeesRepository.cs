using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class EmployeesRepository : baseRepository,IEmployeesRepository
    {
        
        public List<Employees> getEmployees(Employees data)
        {
            var _sql = "select * from Employees";
            var _result = this.ToClass<Employees>(_sql).ToList();
            return _result;
            
        }
    }
}
