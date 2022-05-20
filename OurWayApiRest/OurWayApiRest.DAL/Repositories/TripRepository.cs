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
        public override async Task<Trip> Update(Trip entity)
        {
            bool valida = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"
UPDATE trip SET
dTrip = @dTrip 
, dClosed = @dClosed 
, dFinish = @dFinish 
, cIdBranch = @cIdBranch 
, haveMan = @haveMan 
, enabled = @enabled 
, cIdUserCreated = @cIdUserCreated 
, xTripStatus = @xTripStatus 
, xTripReason = @xTripReason 

WHERE cIdTrip = @cIdTrip
";
                valida = connection.Execute(query.ToString(), entity) == 1;

            }
            //
            if (!valida) return null;

            return entity;
        }
        public override async Task<Trip> Insert(Trip entity)
        {
            bool valida = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO trip(cIdTrip, dTrip, dClosed, dFinish, cIdBranch, haveMan, enabled, cIdUserCreated, xTripStatus, xTripReason) VALUES (@cIdTrip, @dTrip, @dClosed, @dFinish, @cIdBranch, @haveMan, @enabled, @cIdUserCreated, @xTripStatus, @xTripReason)";
                valida = connection.Execute(query, entity) == 1;
            }
            if (!valida) return null;

            return entity;
        }
        public override async Task<Trip> GetById(Trip entity)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var id = entity.CIdTrip;
                connection.Open();
                string query = "SELECT * FROM trip WHERE cIdTrip = @id";
                return connection.QuerySingleOrDefault<Trip>(query, new { id });
            }
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
