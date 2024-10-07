using System.ComponentModel.DataAnnotations;

namespace TMS1.Model.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}

