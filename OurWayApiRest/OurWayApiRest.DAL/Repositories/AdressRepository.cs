using OurWayApiRest.DAL.Repositories.Contracts;
using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OurWayApiRest.DAL.Repositories
{
    public class AdressRepository : Repository<Adress>, IAdressRepository
    {
        public AdressRepository(OurWayContext db) : base(db) {}
        

    }
}
