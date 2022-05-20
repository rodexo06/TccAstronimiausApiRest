using Dapper;
using MySql.Data.MySqlClient;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OurWayApiRest.DAL.Repositories
{
    public class CheckinOutRepository : Repository<CheckinOut>, ICheckinOutRepository
    {
        public CheckinOutRepository(OurWayContext db) : base(db)
        {
        }
        public override async Task<CheckinOut> Update(CheckinOut entity)
        {
            bool valida = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"
UPDATE checkinout SET
cIdUser = @cIdUser 
, cIdTrip = @cIdTrip 
, dCheckin = @dCheckin 
, dCheckout = @dCheckout 
, xCoordIn = @xCoordIn 
, yCoordIn = @yCoordIn 
, xCoordOut = @xCoordOut 
, yCoordOut = @yCoordOut 
, enabled = @enabled 
, dLastUpdate = @dLastUpdate 

WHERE cIdCheckinOut = @cIdCheckinOut
";
                valida = connection.Execute(query.ToString(), entity) == 1;

            }
            //
            if (!valida) return null;

            return entity;
        }
        public override async Task<CheckinOut> Insert(CheckinOut entity)
        {
            bool valida = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO checkinout(cIdCheckinOut, cIdUser, cIdTrip, dCheckin, dCheckout, xCoordIn, yCoordIn, xCoordOut, yCoordOut, enabled, dLastUpdate) VALUES (@cIdCheckinOut, @cIdUser, @cIdTrip, @dCheckin, @dCheckout, @xCoordIn, @yCoordIn, @xCoordOut, @yCoordOut, @enabled, @dLastUpdate)";
                valida = connection.Execute(query, entity) == 1;
            }
            if (!valida) return null;

            return entity;
        }
        public override async Task<CheckinOut> GetById(CheckinOut entity)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var id = entity.CIdCheckinOut;
                connection.Open();
                string query = "SELECT * FROM checkinout WHERE cIdCheckinOut = @id";
                return connection.QuerySingleOrDefault<CheckinOut>(query, new { id });
            }
        }
        public override async Task<IEnumerable<CheckinOut>> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM CheckinOut";
                return await connection.QueryAsync<CheckinOut>(query);
            }
        }
        public async Task<IEnumerable<CheckinOut>> GetTripCard()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"SELECT DISTINCT * FROM CheckinOut 
 where enabled = 1 and
 (12742 * asin(sqrt(0.5 -COS(((xcoordin) - (-23.5257433)) * 0.017453292519943295)/2+COS((-23.5257433) * 0.017453292519943295) * COS((xcoordin) * 0.017453292519943295) * (1-COS(((ycoordin)-(-46.6495967)) * 0.017453292519943295))/2))) < 0.3
 ;";
                return await connection.QueryAsync<CheckinOut>(query);
            }
        }
    }
}
