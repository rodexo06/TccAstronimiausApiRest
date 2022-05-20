using Dapper;
using MySql.Data.MySqlClient;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System.Collections.Generic;
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
        public override async Task<User> Insert(User entity)
        {
            bool valida = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO user(cIdUser, cLogin, sUserName, sEmail, enabled, dLastUpdate, dCreated) VALUES (@cIdUser, @cLogin, @sUserName, @sEmail, @enabled, @dLastUpdate, @dCreated)";
                valida = connection.Execute(query, entity) == 1;
            }
            if (!valida) return null;

            return entity;
        }
        public override async Task<User> GetById(User entity)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var id = entity.cIdUser;
                connection.Open();
                string query = "SELECT * FROM user WHERE cIdUser = @id";
                return connection.QuerySingleOrDefault<User>(query, new { id });
            }
        }
        public override async Task<IEnumerable<User>> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM user";
                return await connection.QueryAsync<User>(query);
            }
        }
    }
}
