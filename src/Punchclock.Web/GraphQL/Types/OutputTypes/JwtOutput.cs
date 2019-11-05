using System;

namespace Punchclock.Web.GraphQL.Types.OutputTypes
{
    public class JwtOutput
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}