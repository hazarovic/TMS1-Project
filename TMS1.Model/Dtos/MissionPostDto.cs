using System.ComponentModel.DataAnnotations;

namespace TMS1.Model.Dtos
{
    public class MissionPostDto
    {
        public int MissionId { get; set; }
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
    }
}
