using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMS1.Model.Entity
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } 

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Roles Role { get; set; } 

        public ICollection<Mission> Missions { get; set; } = new List<Mission>();
    }
}

