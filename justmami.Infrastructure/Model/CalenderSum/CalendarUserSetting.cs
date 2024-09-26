using DBDesign.Model.UserSum;

namespace DBDesign.Model.CalenderSum
{
    public class CalendarUserSetting
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CalendarId { get; set; }
        public Guid CalendarViewTypeID { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Calendar Calendar { get; set; }
        public CalendarViewType CalendarViewType { get; set; }
    }
}
