using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace ChatHub
{
    public class ChatHub : Hub<IClient>
    {
        // id : name
        static Dictionary<string, string> onlineUsers = new Dictionary<string, string>();

        public override Task OnConnected()
        {
            var token = Context.QueryString.Get("Token");
            var userName = "";
            foreach (var cl in new JwtSecurityTokenHandler().ReadJwtToken(token).Claims)
            {
                if(cl.Type == "nameid")
                {
                    userName = cl.Value;
                    break;
                }
            }

            onlineUsers[Context.ConnectionId] = userName;
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            onlineUsers.Remove(Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }



        public bool SendMessage(string text, string toFriend)
        {
            string friendId = onlineUsers.Where(u => u.Value == toFriend).FirstOrDefault().Key;

            if (friendId != null)
            {
                Clients.Client(friendId).GetMessage(text, onlineUsers[Context.ConnectionId]);
                return true;
            }
            return false;
        }

    }

    public interface IClient
    {
        void GetMessage(string text, string fromFriend);
    }
}