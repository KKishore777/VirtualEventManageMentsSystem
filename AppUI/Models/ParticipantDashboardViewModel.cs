namespace AppUI.Models
{
    public class ParticipantDashboardViewModel
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventCategory { get; set; }

        public string SessionTitle { get; set; }
        public DateTime SessionStart { get; set; }

        public string Description { get; set; }
        public bool IsAttended { get; set; }
    }
}
