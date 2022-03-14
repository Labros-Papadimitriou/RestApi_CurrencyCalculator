using System.ComponentModel.DataAnnotations;

namespace RestApi_CurrencyCalculator.AuthenticationViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
