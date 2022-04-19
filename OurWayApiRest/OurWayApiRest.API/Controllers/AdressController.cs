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
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();
            if (result == null)
            {
                NotificarErro("endereço não encontrado!");
                return CustomResponse();
            }
            return CustomResponse(result);
        }
    }
}
