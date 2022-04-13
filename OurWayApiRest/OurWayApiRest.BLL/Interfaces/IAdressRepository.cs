using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OurWayApiRest.BLL.Interfaces
{
    public interface IAdressRepository : IRepository<Adress>
    {
        Task<Adress> GetAdress(int id);
    }
}
