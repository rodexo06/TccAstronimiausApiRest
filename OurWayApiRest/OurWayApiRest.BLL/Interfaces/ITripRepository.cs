using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OurWayApiRest.BLL.Interfaces
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<IEnumerable<Trip>> GetByBranch(int id);
        Task<IEnumerable<Trip>> GetByDate(DateTime dataInicio, DateTime dataFinal);

    }
}
