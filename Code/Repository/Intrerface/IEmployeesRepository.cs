using Model;
using System.Collections.Generic;

namespace Repository
{
    public interface IEmployeesRepository
    {
        List<Employees> getList(Employees data);
        Employees getInfo(int id);

        ReturnResult create(Employees data);
        ReturnResult update(Employees data);
        ReturnResult del(int id);

    }
}
