using GraphQL;
using GraphQL.Types;
using Punchclock.Web.GraphQL.Types;

namespace Punchclock.Web.GraphQL
{
    public class PunchclockSchema : Schema
    {
        public PunchclockSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<RootQuery>();
        }
    }
}