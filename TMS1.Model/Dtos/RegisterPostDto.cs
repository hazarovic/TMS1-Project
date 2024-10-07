using System.ComponentModel.DataAnnotations;

namespace TMS1.Model.Dtos
{
    public class RegisterPostDto
    {
        public string first_name { get; set; } 
        public string last_name { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email {  get; set; }
    }
}
