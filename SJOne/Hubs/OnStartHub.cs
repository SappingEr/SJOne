using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SJOne.Models;

namespace SJOne.Hubs
{
    
    public class OnStartHub : Hub
    {
        private static List<OnStartUser> Users = new List<OnStartUser>();
        private static string mainId;
        private static int userCount;

       
        public void SendStatus(bool readiness)
        {
            var id = Context.ConnectionId;
            var item = Users.FirstOrDefault(x => x.ConnectionId == id);
            if (item != null && readiness == true && item.Readiness == false)
            {
                item.Readiness = readiness;                
                Clients.All.addStatusReadiness(id, readiness);                
                var readinessCount = Users.Where(u => u.Readiness == true).Count();
                if (readinessCount == userCount)
                {
                    bool start = true;
                    Clients.Client(mainId).addStartButton(start);
                }
            }            
        }

        public void Redirect(bool redirect)
        {
            Clients.All.redirectToHandTiming(redirect);
        }

        public void UserCount(int count)
        {
            
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                mainId = item.ConnectionId;
                userCount = count;
            }
               
        }

        // Подключение нового пользователя
        public void Connect(string userNS)
        {
            var id = Context.ConnectionId;

            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new OnStartUser { ConnectionId = id, UserNS = userNS, Readiness = false });
                
                Clients.Caller.onConnected(id, userNS, Users);
                
                Clients.AllExcept(id).onNewUserConnected(id, userNS);               
            }
        }
        
        
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}
