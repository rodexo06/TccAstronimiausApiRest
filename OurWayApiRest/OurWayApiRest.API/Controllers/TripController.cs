using Microsoft.AspNetCore.Mvc;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System;
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
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Trip model)
        {
            try
            {
                var result = _repository.Update(model).Result;
                //
                if (result == null)
                {
                    NotificarErro("viagem não encontrado!");
                    return CustomResponse();
                }
                return CustomResponse(result);
            }
            catch (Exception)
            {
                NotificarErro("problema encontrado!");
                return CustomResponse();
            }

        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Trip model)
        {
            try
            {
                var result = _repository.Insert(model).Result;
                //
                if (result == null)
                {
                    NotificarErro("viagem não encontrado!");
                    return CustomResponse();
                }
                return CustomResponse(result);
            }
            catch (Exception)
            {
                NotificarErro("problema encontrado!");
                return CustomResponse();
            }
        }
        [HttpGet]
        [Route("getall")]
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
