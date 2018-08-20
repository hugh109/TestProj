using Model;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IEmployeeService
    {
        List<Employees> getList(Employees data);      
        Employees getInfo(int id);

        ReturnResult update(Employees data);
        ReturnResult del(int id);
    }
}
