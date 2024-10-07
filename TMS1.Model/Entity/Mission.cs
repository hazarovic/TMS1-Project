using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS1.Model.Entity
{
    //[Table("Mission")]
    public class Mission
    {
        // foreign key for user 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]           
        public int MissionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public DateTime DueDate { get; set; }   
        public MissionStatus.Status Status { get; set; } 
        public MissionPriority.Priority Priority { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }      

    }
}
