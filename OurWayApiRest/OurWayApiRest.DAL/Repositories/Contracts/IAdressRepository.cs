using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurWayApiRest.DAL.Repositories.Contracts
{
    interface IAdressRepository
    {
        public List<Adress> AllAdress();
        public Adress GetAdress(Adress adress);
        public void InsertAdress(Adress adress);
        public void UpdateAdress(Adress adress);
        public void DeleteAdress(Adress adress);
    }
}
