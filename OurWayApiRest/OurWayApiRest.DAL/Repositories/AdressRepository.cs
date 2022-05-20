using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace OurWayApiRest.DAL.Repositories
{
    public class AdressRepository : Repository<Adress>, IAdressRepository
    {

        public AdressRepository(OurWayContext db) : base(db) { }
        public override async Task<Adress> Update(Adress entity)
        {
            bool valida = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"
UPDATE address SET
sStreet = @sStreet 
, sNumber = @sNumber 
, sComplement = @sComplement 
, sZipCode = @sZipCode 
, cIdState = @cIdState 
, cIdCountry = @cIdCountry 
, xCoord = @xCoord 
, yCoord = @yCoord 
, enabled = @enabled 
, dLastUpdate = @dLastUpdate 

WHERE cIdAddress = @cIdAddress
";
                valida = connection.Execute(query.ToString(), entity) == 1;

            }
            //
            if (!valida) return null;

            return entity;
        }
        public override async Task<Adress> Insert(Adress entity)
        {
            bool valida = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO address(cIdAddress, sStreet, sNumber, sComplement, sZipCode, cIdState, cIdCountry, xCoord, yCoord, enabled, dLastUpdate) VALUES (@cIdAddress, @sStreet, @sNumber, @sComplement, @sZipCode, @cIdState, @cIdCountry, @xCoord, @yCoord, @enabled, @dLastUpdate)";
                valida = connection.Execute(query, entity) == 1;
            }
            if (!valida) return null;

            return entity;
        }
        public override async Task<Adress> GetById(Adress entity)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var id = entity.CIdAddress;
                connection.Open();
                string query = "SELECT * FROM address WHERE cIdAddress = @id";
                return connection.QuerySingleOrDefault<Adress>(query, new { id });
            }
        }
        public async Task<Adress> GetAdress(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public override async Task<IEnumerable<Adress>> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM address";
                return await connection.QueryAsync<Adress>(query);
            }
        }
    }
}
