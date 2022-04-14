using Microsoft.AspNetCore.Mvc;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using OurWayApiRest.DAL;

namespace OurWayApiRest.API.Controllers
{
    public class AdressController : MainController
    {
        private readonly IAdressRepository _repository;
        private readonly IDBHelper _db;
        public AdressController(IAdressRepository repository, IDBHelper db)
        {
            _repository = repository;
            _db = db;

        }
        [HttpGet]
        [Route("enderecos")]
        public async Task<IEnumerable<Adress>> GetAll()
        {
            var teste =  await _repository.GetAll();
            return teste;
        }
    }
}
