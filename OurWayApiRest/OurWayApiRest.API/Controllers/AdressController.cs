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
        public AdressController(IAdressRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;

        }
        [HttpGet]
        [Route("enderecos")]
        public async Task<IEnumerable<Adress>> GetAll()
        {
            var lista = await _repository.GetAll();
            return lista;
        }
    }
}
