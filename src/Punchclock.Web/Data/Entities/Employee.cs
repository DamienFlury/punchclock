using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Punchclock.Web.Data.Entities
{
    public class Employee : IdentityUser
    {
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
    }
}