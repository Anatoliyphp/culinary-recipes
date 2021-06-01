using System.ComponentModel.DataAnnotations;
 
namespace recipe_api.Infrastructure
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }
         
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}