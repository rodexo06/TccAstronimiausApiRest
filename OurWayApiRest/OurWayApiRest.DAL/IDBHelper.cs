using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace OurWayApiRest.DAL
{
    public interface IDBHelper
    {
        IDataReader ExecuteReaderProc(string storedProcedure, params object[] parametros);
        bool ExecuteNonQueryProc(string storedProcedure, params object[] parametros);
        IDataReader ExecuteReader(string query, params object[] parametros);
        bool ExecuteNonQuery(string query, params object[] parametros);
        void PreencherParametros(DbCommand cmd, object[] parametros);
    }
}
