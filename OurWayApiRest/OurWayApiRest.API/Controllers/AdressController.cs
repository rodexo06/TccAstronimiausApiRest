using Microsoft.AspNetCore.Mvc;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using OurWayApiRest.DAL;
using System;

namespace OurWayApiRest.API.Controllers
{
    public class AdressController : MainController
    {
        private readonly IAdressRepository _repository;
        public AdressController(IAdressRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;

        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Adress model)
        {
<<<<<<< HEAD
            try
            {
                var result = _repository.Update(model).Result;
                //
                if (result == null)
                {
                    NotificarErro("endereço não encontrado!");
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
        public IActionResult Insert(Adress model)
        {
            try
            {
                var result = _repository.Insert(model).Result;
                //
                if (result == null)
                {
                    NotificarErro("endereço não encontrado!");
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
            try
            {
                var result = await _repository.GetAll();
                if (result == null)
                {
                    NotificarErro("endereço não encontrado!");
                    return CustomResponse();
                }
                return CustomResponse(result);
            }
            catch (Exception)
            {
                NotificarErro("problema encontrado!");
                return CustomResponse();
            }
=======
            return await _repository.GetAll();
>>>>>>> 6187bc0be528b798438b9c5409c669660344a01f
        }
    }
}
