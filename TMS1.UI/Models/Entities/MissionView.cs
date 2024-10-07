
namespace TMS1.UI.Models.Entities
{
    public class MissionView
    {
        public int MissionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
