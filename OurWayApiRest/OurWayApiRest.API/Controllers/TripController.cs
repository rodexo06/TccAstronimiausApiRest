using Microsoft.AspNetCore.Mvc;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OurWayApiRest.API.Controllers
{
    
    public class TripController : MainController
    {
        private readonly ITripRepository _repository;
        public TripController(ITripRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;

        }
        [HttpGet]
        [Route("getall")]
        //public async Task<IEnumerable<Trip>> GetAll()
        //{
        //    var lista = await _repository.GetAll();
        //    if (lista == null)
        //    {
        //        NotificarErro("viagem não encontrado!");
        //        return CustomResponse();
        //    }
        //    return CustomResponse(lista);
        //}
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();
            if (result == null)
            {
                NotificarErro("viagem não encontrado!");
                return CustomResponse();
            }
            return CustomResponse(result);
        }
    }
}
