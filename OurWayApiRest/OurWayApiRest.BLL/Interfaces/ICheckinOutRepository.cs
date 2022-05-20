using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OurWayApiRest.BLL.Interfaces
{
    public interface ICheckinOutRepository : IRepository<CheckinOut>
    {
        Task<IEnumerable<CheckinOut>> GetTripCard();
    }
}
