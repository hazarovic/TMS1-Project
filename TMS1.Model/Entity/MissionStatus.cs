namespace TMS1.Model.Entity
{
    public class MissionStatus // internal yerine public yaptık
    {
        public enum Status
        {
            ToDo = 1,
            InProgress = 2,
            Completed = 3,
            Aborted = 4
        }
    }
}
