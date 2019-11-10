using GraphQL.Types;
using Punchclock.Web.Data.Entities;

namespace Punchclock.Web.GraphQL.Types.OutputTypes
{
    public class EntryType : ObjectGraphType<Entry>
    {
        public EntryType()
        {
            Field(x => x.Id);
            Field<DateTimeGraphType>("checkIn");
            Field(x => x.CheckOut, type: typeof(DateTimeGraphType), nullable: true);
            Field<EmployeeType>("employee");
        }
    }
}