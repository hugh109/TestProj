using Model;
using System.Collections.Generic;

namespace Repository
{
    public interface IEmployeesRepository
    {
        List<Employees> getEmployees(Employees data);
    }
}
