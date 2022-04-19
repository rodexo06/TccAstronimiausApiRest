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
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(OurWayContext db) : base(db)
        {
        }
        public override async Task<IEnumerable<Trip>> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Trip";
                return await connection.QueryAsync<Trip>(query);
            }
        }
        public Task<IEnumerable<Trip>> GetByBranch(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Trip>> GetByDate(DateTime dataInicio, DateTime dataFinal)
        {
            throw new NotImplementedException();
        }
    }
}
