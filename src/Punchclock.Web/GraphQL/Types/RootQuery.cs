using System;
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
                if (user.IsInRole("admin"))
                {
                    return context.Entries.Include(e => e.Employee).ThenInclude(e => e.Department);
                }
                return context.Entries.Where(e => e.Employee.UserName == user.Identity.Name).Include(e => e.Employee)
                    .ThenInclude(e => e.Department);
            });
            
            Field<ListGraphType<EmployeeType>>("employees", resolve: ctx => 
                context.Employees.Include(e => e.Department)
                    .Include(e => e.Entries));

            Field<ListGraphType<DepartmentType>>("departments", resolve: ctx =>
                context.Departments);

            Field<DateTimeGraphType>("lastCheckIn", resolve: ctx =>
            {
                var user = (ClaimsPrincipal)ctx.UserContext;
                var isUserAuthenticated = ((ClaimsIdentity) user.Identity).IsAuthenticated;
                if (!isUserAuthenticated) throw new ExecutionError("Not authenticated");
                
                var lastEntry = context.Entries.Where(e => e.Employee.UserName == user.Identity.Name).OrderByDescending(e => e.Id).FirstOrDefault();

                return lastEntry switch
                {
                    { CheckOut: null, CheckIn: var checkIn } => checkIn as DateTime?,
                    _ => null
                };
            });

            FieldAsync<EntryType>("entry", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: async ctx =>
                {
                    var user = (ClaimsPrincipal)ctx.UserContext;
                    var isUserAuthenticated = ((ClaimsIdentity) user.Identity).IsAuthenticated;
                    if (!isUserAuthenticated) throw new ExecutionError("Not authenticated");
                    if(!user.IsInRole("admin")) throw new ExecutionError("Not an admin");
                    
                    var id = ctx.GetArgument<int>("id");
                    return await context.Entries.Include(e => e.Employee).FirstOrDefaultAsync(e => e.Id == id);
                });

        }
    }
}