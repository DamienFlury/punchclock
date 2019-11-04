using GraphQL.Types;
using Punchclock.Web.Data.Entities;

namespace Punchclock.Web.GraphQL.Types.OutputTypes
{
    public class DepartmentType : ObjectGraphType<Department>
    {
        public DepartmentType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field<ListGraphType<EmployeeType>>("employees");
        }
    }
}