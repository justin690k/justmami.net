namespace DBDesign.Model.UserSum
{
    public class UserSetting
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid UserLanguageId { get; set; }
        public Guid NotifactionTypeId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public UserLanguage UserLanguage { get; set; }
        public NotifactionType NotifactionType { get; set; }
    }
}
