using System.ComponentModel.DataAnnotations;
using TMS1.UI.Models.Entities;

namespace TMS1.UI.Models.MissionViewModel
{
    public class CreateMissionViewModel
    {
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }//requir
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public MissionStatus.Status Status { get; set; }
        public MissionPriority.Priority Priority { get; set; }
        public string ErrorMessage { get; set; }
    }
}
