using GraphQL.Types;

namespace Punchclock.Web.GraphQL.Types.InputTypes
{
    public class EmployeeInputType : InputObjectGraphType<EmployeeInput>
    {
        public EmployeeInputType()
        {
            Field(x => x.Email);
            Field(x => x.Password);
        }
    }
}