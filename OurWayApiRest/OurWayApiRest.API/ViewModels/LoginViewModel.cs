using System.ComponentModel.DataAnnotations;

namespace OurWayApiRest.API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} Obrigatorio!")]
        [Display(Name = "usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} Obrigatorio!")]
        [Display(Name = "senha")]
        public string PassWord { get; set; }
    }
}
