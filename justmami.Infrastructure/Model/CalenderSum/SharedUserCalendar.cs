using DBDesign.Model.UserSum;

namespace DBDesign.Model.CalenderSum
{
    public class SharedUserCalendar
    {
        public Guid SharedUserId { get; set; }
        public Guid CalendarId { get; set; }
        public Guid SharedUserVisibilityId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Calendar Calendar { get; set; }
        public SharedUserVisibility SharedUserVisibility { get; set; }
    }
}
