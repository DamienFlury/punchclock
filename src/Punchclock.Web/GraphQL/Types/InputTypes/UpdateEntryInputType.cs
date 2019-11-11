using GraphQL.Types;
using Punchclock.Web.Data.Entities;

namespace Punchclock.Web.GraphQL.Types.InputTypes
{
    public class UpdateEntryInputType : InputObjectGraphType<UpdateEntryInput>
    {
        public UpdateEntryInputType()
        {
            Field(x => x.Id);
            Field(x => x.CheckIn, type: typeof(DateTimeGraphType), nullable: true);
            Field(x => x.CheckOut, type: typeof(DateTimeGraphType), nullable: true);
            Field(x => x.EmployeeId, nullable: true);
        }
    }
}