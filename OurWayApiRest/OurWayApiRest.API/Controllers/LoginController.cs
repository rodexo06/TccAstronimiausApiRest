﻿using Microsoft.AspNetCore.Mvc;
using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using OurWayApiRest.DAL;
using OurWayApiRest.API.ViewModels;

namespace OurWayApiRest.API.Controllers
{
    public class LoginController : MainController
    {
        private readonly ILoginRepository _repository;
        public LoginController(ILoginRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }
        [HttpPost]
        [Route("Logar")]
        public IActionResult Logar(LoginViewModel login)
        {
            if ((string.IsNullOrEmpty(login.UserName)) && (string.IsNullOrEmpty(login.PassWord))) 
            {
                NotificarErro("usuario ou senha não podem ser nulo");
                return CustomResponse();
            }   
            //
            var result = _repository.PostLogar(login.UserName, login.PassWord);
            if (result == null)
            {
                NotificarErro("usuario não encontrado!");
                return CustomResponse();
            }
            //
<<<<<<< HEAD
=======
            var result = _repository.PostLogar(loginViewModel.UserName, loginViewModel.PassWord);
            if (result == null)
            {
                NotificarErro("Login invalido!");
                return CustomResponse();
            }
            //
>>>>>>> 6187bc0be528b798438b9c5409c669660344a01f
            return CustomResponse(result);

        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Login model)
        {
            var result = _repository.Update(model).Result;
            //
            if (result == null)
            {
                NotificarErro("login não encontrado!");
                return CustomResponse();
            }
            return CustomResponse(result);
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Login model)
        {
            var result = _repository.Insert(model).Result;
            //
            if (result == null)
            {
                NotificarErro("login não encontrado!");
                return CustomResponse();
            }
            return CustomResponse(result);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();
            if (result == null)
            {
                NotificarErro("login não encontrado!");
                return CustomResponse();
            }
            return CustomResponse(result);
        }
    }
}
