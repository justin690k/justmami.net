using DBDesign.Model.UserSum;

namespace DBDesign.Model.CalenderSum
{
    public class Calendar
    {
        public Guid Id { get; set; }
        public Guid Owner {  get; set; }
        public string Name { get; set; }
        public Guid CalendarTypeId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public CalendarType CalendarType { get; set; }
    }
}
