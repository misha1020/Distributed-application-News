using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSendServe
{
    [Serializable]
    public struct MessageSendRecieve
    {
        public string hostIP { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string IP { get; set; }

        public MessageSendRecieve(string IP, string hostip, string log, string pass)
        {
            this.IP = IP;
            this.hostIP = hostip;
            this.login = log;
            this.password = pass;
        }
    }
}
