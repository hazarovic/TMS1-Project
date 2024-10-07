using System.ComponentModel.DataAnnotations;

namespace TMS1.UI.Models.AccountViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
    }
}