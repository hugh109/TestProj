using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Repository
{
    public class baseRepository : IDisposable
    {
        private SqlConnection _conn;

        public baseRepository()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public void Dispose()
        {
            this.ToConnClose();
        }

        #region baseEvent

        public bool ToConnOpen()
        {
            var _result = true;
            try
            {
                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }
            }
            catch
            {
                _result = false;
            }

            return _result;
        }

        public bool ToConnClose()
        {
            var _result = true;
            try
            {
                if (_conn.State != System.Data.ConnectionState.Closed)
                {
                    _conn.Close();
                }
            }
            catch
            {
                _result = false;
            }

            return _result;
        }
        #endregion
        
        //-------------------------------------
        /// <summary>
        /// 回傳指定類別 -- 需傳入SQL參數
        /// </summary>
        public IList<T> ToClass<T>(string sql, DynamicParameters Params) where T : new()
        {
            if (string.IsNullOrEmpty(sql) == true)
            {
                return null;
            }
            if (Params != null)
            {
                var _result = this._conn.Query<T>(sql, Params).ToList();
                return _result;
            }
            else
            {
                var _result = this._conn.Query<T>(sql).ToList();
                return _result;
            }

        }

        public IList<T> ToClassByObj<T>(string sql, object Params) where T : new()
        {
            if (string.IsNullOrEmpty(sql) == true)
            {
                return null;
            }
            if (Params != null)
            {
                var _result = this._conn.Query<T>(sql, Params).ToList();
                return _result;
            }
            else
            {
                var _result = this._conn.Query<T>(sql).ToList();
                return _result;
            }

        }

        /// <summary>
        /// 回傳指定類別
        /// </summary>
        public IList<T> ToClass<T>(string sql) where T : new()
        {
            return this.ToClass<T>(sql, null);
        }

        /// <summary>
        /// 執行指定的SQL語法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public bool ToExecute(string sql, DynamicParameters Params)
        {
            bool _flag = false;
            int _result = 0;
            if (string.IsNullOrEmpty(sql) == true)
            {

            }
            if (Params != null)
            {
                _result = this._conn.Execute(sql, Params);
            }
            else
            {
                _result = this._conn.Execute(sql, Params);
            }
            _flag = (_result == 0) ? false : true;
            return _flag;
        }

        public bool ToExecute(string sql, object Params)
        {
            bool _flag = false;
            int _result = 0;
            if (string.IsNullOrEmpty(sql) == true)
            {

            }
            if (Params != null)
            {
                _result = this._conn.Execute(sql, Params);
            }
            else
            {
                _result = this._conn.Execute(sql, Params);
            }
            _flag = (_result == 0) ? false : true;
            return _flag;
        }

    }
}
