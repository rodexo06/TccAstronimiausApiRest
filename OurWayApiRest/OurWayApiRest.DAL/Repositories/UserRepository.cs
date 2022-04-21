using Dapper;
using MySql.Data.MySqlClient;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OurWayApiRest.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OurWayContext db) : base(db)
        {
        }
        public override async Task<User> Update(User entity)
        {
            bool valida = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"
UPDATE user SET
cLogin = @cLogin 
, sUserName = @sUserName 
, sEmail = @sEmail 
, enabled = @enabled 
, dLastUpdate = @dLastUpdate 
, dCreated = @dCreated 

WHERE cIdUser = @cIdUser
";
                valida = connection.Execute(query.ToString(), entity) == 1;

            }
            //
            if (!valida) return null;

            return entity;
        }
    }
}
