using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Logar(LoginViewModel loginViewModel)
        {
            if ((string.IsNullOrEmpty(loginViewModel.UserName)) && (string.IsNullOrEmpty(loginViewModel.PassWord))) 
            {
                NotificarErro("usuario ou senha não podem ser nulo");
                return CustomResponse();
            }
            //
            return CustomResponse(loginViewModel);

        }
    }
}
