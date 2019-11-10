using GraphQL.Types;
using Punchclock.Web.Data.Entities;

namespace Punchclock.Web.GraphQL.Types.InputTypes
{
    public class EntryInputType : InputObjectGraphType<Entry>
    {
        public EntryInputType()
        {
            Field(x => x.Id);
            Field(x => x.CheckIn);
            Field(x => x.CheckOut, type: typeof(DateTimeGraphType), nullable: true);
        }
    }
}