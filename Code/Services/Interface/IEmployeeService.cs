using Model;
using System.Collections.Generic;

namespace Services
{
    public interface IEmployeeService
    {
        List<Employees> getEmployees(PageInfo page, Employees data);

    }
}
