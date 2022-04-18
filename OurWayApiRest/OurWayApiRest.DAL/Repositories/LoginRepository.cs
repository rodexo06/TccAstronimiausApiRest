using Dapper;
using MySql.Data.MySqlClient;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OurWayApiRest.DAL.Repositories
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        public LoginRepository(OurWayContext db) : base(db)
        {
        }

        public Login PostLogar(string username, string password)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM login WHERE cLogin = @username and cPassword = @password";
                return connection.QuerySingleOrDefault<Login>(query, new { username, password });
            }
        }
    }
}
