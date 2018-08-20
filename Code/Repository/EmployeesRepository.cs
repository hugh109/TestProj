using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class EmployeesRepository : baseRepository, IEmployeesRepository
    {
        string _sql = string.Empty;

        public List<Employees> getList(Employees data)
        {
            _sql = "select * from Employees order by LastName,FirstName";
            var _result = this.ToClass<Employees>(_sql).ToList();
            return _result;

        }

        public Employees getInfo(int id)
        {
            var _data = new Employees();
            _data.EmployeeID = id;
            _sql = @"select * from Employees where EmployeeID=@EmployeeID";

            var _result = ToClass<Employees>(_sql, _data).FirstOrDefault();
            return _result;

        }

        public ReturnResult create(Employees data)
        {
            _sql = "insert into Employees ";
            string[] _columns = "LastName,FirstName".Split(',');
            _sql = appendInsertStr(_sql, _columns);
            _sql += " select ident_current('Employees') as uid";
            var _result = new ReturnResult();
            try
            {
                var _uid = ToClass<int>(_sql, data).Single();
                _result.Code = _uid.ToString();
                _result.Msg = "";
                _result.Success = true;

            }
            catch (Exception ex)
            {
                _result.Code = "0";
                _result.Msg = string.Format("新增異常:({0})", ex.Message);
                _result.Success = false;
            }

            return _result;
        }


        public ReturnResult update(Employees data)
        {
            _sql = @"update Employees ";
            string[] _columns = "LastName,FirstName,Title,BirthDate".Split(',');
            _sql = appendUpdateStr(_sql, _columns);
            _sql += " where EmployeeID=@EmployeeID";

            var _result = ToExecute(_sql, data);
            return _result;
        }

        public ReturnResult del(int id)
        {
            _sql = @"delete Employees where EmployeeID=@EmployeeID";
            var _data = new Employees();
            _data.EmployeeID = id;

            var _result = ToExecute(_sql, _data);
            return _result;
        }


    }
}
