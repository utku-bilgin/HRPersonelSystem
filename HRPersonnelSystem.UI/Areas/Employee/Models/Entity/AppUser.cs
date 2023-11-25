using Microsoft.AspNetCore.Identity;

namespace HRPersonnelSystem.UI.Areas.Employee.Models.Entity
{
    public class AppUser: IdentityUser<Guid>, IBaseEntity
    {
    }
}
