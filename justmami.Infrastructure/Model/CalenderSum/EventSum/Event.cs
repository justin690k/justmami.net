using DBDesign.Model.UserSum;

namespace DBDesign.Model.CalenderSum.Event
{
    public class Event
    {
        public Guid Id { get; set; }
        public Guid Owner {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
