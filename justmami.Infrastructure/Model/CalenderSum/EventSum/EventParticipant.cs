using DBDesign.Model.UserSum;

namespace DBDesign.Model.CalenderSum.Event
{
    public class EventParticipant
    {
        public Guid EventId { get; set; }
        public Guid SharedUserId { get; set; }
        public Guid EventParticipantsStatusId { get; set; }

        public Event Event { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public EventParticipantsStatus ParticipantsStatus { get; set; }
    }
}
