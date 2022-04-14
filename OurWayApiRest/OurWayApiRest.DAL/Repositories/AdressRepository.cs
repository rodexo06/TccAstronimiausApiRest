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
