using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
{
    struct  MessageSendRecieve
    {
        public string hostIP;
        public string login;
        public string password;

        public MessageSendRecieve(string ip, string log, string pass)
        {
            this.hostIP = ip;
            this.login = log;
            this.password = pass;
        }
    }
}
