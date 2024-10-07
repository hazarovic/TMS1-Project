using System.ComponentModel.DataAnnotations;

namespace TMS1.Model.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public int RoleId { get; set; }
        // Add other fields as necessary
    }
}
