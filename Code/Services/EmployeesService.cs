using Model;
using Repository;
using Services.Interface;
using System.Collections.Generic;
using System;

namespace Services
{
    public class EmployeesService : IEmployeeService
    {
        private IEmployeesRepository _repository;

        public EmployeesService()
        {
            _repository = new EmployeesRepository();
        }
        

        List<Employees> IEmployeeService.getList(Employees data)
        {
            var _result = _repository.getList(data);

            return _result;
        }

        public Employees getInfo(int id)
        {
            var _result = _repository.getInfo(id);

            return _result;
        }
        

        public ReturnResult update(Employees data)
        {
            var _result = new ReturnResult();

            if (data.EmployeeID == 0)
            {
                _result = _repository.create(data);
                int _tmpID = 0;
                int.TryParse(_result.Code, out _tmpID);
                data.EmployeeID = _tmpID;
            }

            _result = _repository.update(data);


            return _result;
        }

        public ReturnResult del(int id)
        {
            var _result = _repository.del(id);

            return _result;
        }

    }
}
