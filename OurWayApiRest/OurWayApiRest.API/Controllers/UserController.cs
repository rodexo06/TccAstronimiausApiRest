using Microsoft.AspNetCore.Mvc;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurWayApiRest.API.Controllers
{
    public class UserController : MainController
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;

        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(User model)
        {
            try
            {
                model.dLastUpdate = DateTime.Now;
                var result = _repository.Update(model).Result;
                //
                if (result == null)
                {
                    NotificarErro("usuario não encontrado!");
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
        public IActionResult Insert(User model)
        {
            try
            {
                model.dLastUpdate = DateTime.Now;
                var result = _repository.Insert(model).Result;
                //
                if (result == null)
                {
                    NotificarErro("usuario não encontrado!");
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
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var result = await _repository.GetById(new User() { cIdUser = id });
                if (result == null)
                {
                    NotificarErro("usuario não encontrado!");
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
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();
            if (result == null)
            {
                NotificarErro("usuario não encontrado!");
                return CustomResponse();
            }
            return CustomResponse(result);
        }
    }
}
