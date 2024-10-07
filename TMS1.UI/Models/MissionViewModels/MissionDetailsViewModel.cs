using TMS1.UI.Models.Entities;

namespace TMS1.UI.Models.MissionViewModel
{
    public class MissionDetailsViewModel
    {
        public int MissionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public MissionStatus.Status Status { get; set; }
        public MissionPriority.Priority Priority { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string ErrorMessage { get; set; }
    }
}