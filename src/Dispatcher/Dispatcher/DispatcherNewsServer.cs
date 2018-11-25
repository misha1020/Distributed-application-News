using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
{
    class DispatcherNewsServer
    {
        struct MessageToRecieve
        {
            public string hostIP;
            public string login;
            public string password;

            public MessageToRecieve(string ip, string log, string pass)
            {
                this.hostIP = ip;
                this.login = log;
                this.password = pass;
            }
        }
    }
}
