using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Punchclock.Web.Data;
using Punchclock.Web.GraphQL.Types.OutputTypes;

namespace Punchclock.Web.GraphQL.Types
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(PunchclockContext context)
        {
            Field<ListGraphType<EntryType>>("entries", resolve: ctx =>
                context.Entries.Include(e => e.Employee)
                    .ThenInclude(e => e.Department));
            
            Field<ListGraphType<EmployeeType>>("employees", resolve: ctx => 
                context.Employees.Include(e => e.Department)
                    .Include(e => e.Entries));

            Field<ListGraphType<DepartmentType>>("departments", resolve: ctx =>
                context.Departments.Include(d => d.Employees)
                    .ThenInclude(e => e.Entries));          
        }
    }
}