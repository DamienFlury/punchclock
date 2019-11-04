using GraphQL.Types;
using Punchclock.Web.Data.Entities;

namespace Punchclock.Web.GraphQL.Types.OutputTypes
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Field(x => x.Id);
            Field(x => x.Email);
            Field<DepartmentType>("department");
        }
    }
}