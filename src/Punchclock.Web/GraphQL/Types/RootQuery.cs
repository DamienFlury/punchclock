using GraphQL.Types;
using Punchclock.Web.Data;
using Punchclock.Web.GraphQL.Types.OutputTypes;

namespace Punchclock.Web.GraphQL.Types
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(PunchclockContext context)
        {
            Field<ListGraphType<EntryType>>("entries", resolve: ctx => context.Entries);
        }
    }
}