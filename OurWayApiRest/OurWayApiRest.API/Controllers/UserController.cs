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
        public IActionResult Update(User user)
        {
            user.dLastUpdate = DateTime.Now.ToString();
           var result = _repository.Update(user).Result;
            //
            if (result == null)
            {
                NotificarErro("usuario não encontrado!");
                return CustomResponse();
            }
            return CustomResponse(result);
        }
    }
}
