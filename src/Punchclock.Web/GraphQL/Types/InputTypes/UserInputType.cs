using GraphQL.Types;

namespace Punchclock.Web.GraphQL.Types.InputTypes
{
    public class UserInputType : InputObjectGraphType<UserInput>
    {
        public UserInputType()
        {
            Field(x => x.Email);
            Field(x => x.Password);
        }
    }
}