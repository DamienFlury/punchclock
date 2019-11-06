using System.Linq;
using System.Security.Claims;
using GraphQL;
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
            {
                var user = (ClaimsPrincipal)ctx.UserContext;
                var isUserAuthenticated = ((ClaimsIdentity) user.Identity).IsAuthenticated;
                if (!isUserAuthenticated) throw new ExecutionError("Not authenticated");
                return context.Entries.Where(e => e.Employee.UserName == user.Identity.Name).Include(e => e.Employee)
                    .ThenInclude(e => e.Department);
            });
            
            Field<ListGraphType<EmployeeType>>("employees", resolve: ctx => 
                context.Employees.Include(e => e.Department)
                    .Include(e => e.Entries));

            Field<ListGraphType<DepartmentType>>("departments", resolve: ctx =>
                context.Departments.Include(d => d.Employees)
                    .ThenInclude(e => e.Entries));
        }
    }
}