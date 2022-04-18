using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurWayApiRest.BLL.Interfaces
{
    public interface ILoginRepository : IRepository<Login>
    {
        Login PostLogar(string username, string password);
    }
}
