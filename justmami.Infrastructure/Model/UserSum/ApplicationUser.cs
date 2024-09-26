using Microsoft.AspNetCore.Identity;

namespace DBDesign.Model.UserSum
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid? ParentID { get; set; }
        public string? Accescode { get; set; }
    }
}
