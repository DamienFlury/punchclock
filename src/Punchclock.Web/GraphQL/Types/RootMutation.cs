using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Instrumentation;
using GraphQL.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Punchclock.Web.Data;
using Punchclock.Web.Data.Entities;
using Punchclock.Web.GraphQL.Types.InputTypes;
using Punchclock.Web.GraphQL.Types.OutputTypes;

namespace Punchclock.Web.GraphQL.Types
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(PunchclockContext context, UserManager<Employee> userManager,
            SignInManager<Employee> signInManager,
            IConfiguration configuration)
        {
            async Task<JwtOutput> CreateTokenAsync(UserInput user)
            {
                var employee = await userManager.FindByEmailAsync(user.Email);
                if (employee is null) return null;

                var result = await signInManager.CheckPasswordSignInAsync(employee, user.Password, false);

                if (!result.Succeeded) return null;

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    configuration["Tokens:Issuer"],
                    configuration["Tokens:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: cred);

                return new JwtOutput
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                };
            }
            
            FieldAsync<JwtOutputType>("createUser",
                arguments: new QueryArguments(new QueryArgument<UserInputType> {Name = "user"}),
                resolve: async ctx =>
                {
                    var user = ctx.GetArgument<UserInput>("user");
                    var employee = new Employee
                    {
                        UserName = user.Email,
                        Email = user.Email,
                        DepartmentId = 1,
                    };

                    var result = await userManager.CreateAsync(employee, user.Password);
                    if (result != IdentityResult.Success) return null;

                    return await CreateTokenAsync(user);
                });

            FieldAsync<JwtOutputType>("createToken",
                arguments: new QueryArguments(new QueryArgument<UserInputType> {Name = "user"}),
                resolve: async ctx =>
                {
                    var user = ctx.GetArgument<UserInput>("user");

                    return await CreateTokenAsync(user);
                });

            FieldAsync<EntryType>("createEntry",
                arguments: new QueryArguments(new QueryArgument<EntryInputType> {Name = "entry"}),
                resolve: async ctx =>
                {
                    var user = (ClaimsPrincipal)ctx.UserContext;
                    var isUserAuthenticated = ((ClaimsIdentity) user.Identity).IsAuthenticated;
                    if (!isUserAuthenticated) return null;
                    
                    var entry = ctx.GetArgument<Entry>("entry");
                    var employee = await context.Employees.FirstOrDefaultAsync(e => e.UserName == user.Identity.Name);
                    if (employee is null) return null;
                    entry.EmployeeId = employee.Id;
                    await context.Entries.AddAsync(entry);
                    await context.SaveChangesAsync();
                    return entry;
                });
        }
    }
}