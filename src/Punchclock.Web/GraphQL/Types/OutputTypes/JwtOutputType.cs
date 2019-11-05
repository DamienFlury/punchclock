using GraphQL.Types;

namespace Punchclock.Web.GraphQL.Types.OutputTypes
{
    public class JwtOutputType : ObjectGraphType<JwtOutput>
    {
        public JwtOutputType()
        {
            Field(x => x.Token);
            Field(x => x.Expiration);
        }
    }
}