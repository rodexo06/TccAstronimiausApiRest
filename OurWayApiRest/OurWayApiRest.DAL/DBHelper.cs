using System;
using System.Collections.Generic;
using System.Text;

namespace OurWayApiRest.DAL
{
    public class DBHelper : IDBHelper
    {
        public static OurWayContext _banco;
        public DBHelper(OurWayContext banco)
        {
            _banco = banco;
        }

        public IDataReader ExecuteReaderProc(string storedProcedure, params object[] parametros)
        {
            var cmd = _banco.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = storedProcedure;
            PreencherParametros(cmd, parametros);
            _banco.Database.OpenConnection();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public bool ExecuteNonQueryProc(string storedProcedure, params object[] parametros)
        {
            SqlCommand cmd = (SqlCommand)_banco.Database.GetDbConnection().CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            PreencherParametros(cmd, parametros);
            _banco.Database.OpenConnection();
            bool retorno;
            try
            {
                cmd.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {
                _ = "Erro: " + ex.ToString();
                retorno = false;
            }
            _banco.Database.CloseConnection();
            return retorno;
        }


        public int LastIdTable(params object[] parametros)
        {
            int LastIdTable = 0;
            try
            {
                var cmd = _banco.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = $"select max(isnull({parametros[0]},0))+1 as max from {parametros[1]}";
                PreencherParametros(cmd, parametros);
                _banco.Database.OpenConnection();
                using var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dr.Read();
                LastIdTable = Convert.ToInt32(dr["max"]);
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
            return LastIdTable;
        }


        public IDataReader ExecuteReader(string query, params object[] parametros)
        {
            var cmd = _banco.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = query;
            PreencherParametros(cmd, parametros);
            _banco.Database.OpenConnection();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public bool ExecuteNonQuery(string query, params object[] parametros)
        {
            _banco.Database.OpenConnection();
            var cmd = _banco.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = query;
            PreencherParametros(cmd, parametros);
            bool retorno;
            try
            {
                cmd.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception ex)
            {
                _ = "Erro: " + ex.ToString();
                retorno = false;
            }
            _banco.Database.CloseConnection();
            return retorno;
        }

        public void PreencherParametros(DbCommand cmd, object[] parametros)
        {
            if (parametros.Length > 0)
            {
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    var parameter = cmd.CreateParameter();
                    parameter.ParameterName = parametros[i].ToString();
                    parameter.Value = parametros[i + 1];
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}
