using Microsoft.AspNetCore.Identity;
namespace Domain.Entities.Securities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; } = new List<IdentityUserRole<Guid>>();
    }
}
