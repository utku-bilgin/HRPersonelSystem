using HRPersonnelSystem.Core.BaseEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Entities
{
    public class AppUser : IdentityUser<Guid>,IBaseEntity
    {

    }
}
