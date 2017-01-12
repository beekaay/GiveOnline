using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveOnline.Models
{
    public class RolesandUsersViewModel
    {
        public virtual List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> IdentRoles { get; set; }
    }
}