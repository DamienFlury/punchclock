using System.Collections.Generic;

namespace Punchclock.Web.Data.Entities
{
    public class Department
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}