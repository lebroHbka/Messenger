using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(ChatHub.Startup))]

namespace ChatHub
{
    public class QueryStringBearerAuthorizeAttribute : AuthorizeAttribute
    {
        static string Secret = Properties.Resources.secretKey;

        public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
        {
            var token = request.QueryString.Get("Token");
            try
            {
                ClaimsPrincipal prinsipial;
                var tokenHandler = new JwtSecurityTokenHandler();
                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                prinsipial = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            return true;
        }

    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                var authorizer = new QueryStringBearerAuthorizeAttribute();
                var module = new AuthorizeModule(authorizer, authorizer);
                GlobalHost.HubPipeline.AddModule(module);
                map.RunSignalR();

            });
        }
    }
}
