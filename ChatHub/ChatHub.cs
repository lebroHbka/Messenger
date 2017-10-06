using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatHub
{
    public class ChatHub : Hub<IClient>
    {
        public void SendMessage(string text)
        {
            Clients.All.GetMessage(text);
        }
    }

    public interface IClient
    {
        void GetMessage(string text);
    }
}