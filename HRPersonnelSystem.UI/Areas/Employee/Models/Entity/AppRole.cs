using Microsoft.AspNetCore.Identity;

namespace HRPersonnelSystem.UI.Areas.Employee.Models.Entity
{
    public class AppRole: IdentityRole<Guid>, IBaseEntity
    {
    }
}
