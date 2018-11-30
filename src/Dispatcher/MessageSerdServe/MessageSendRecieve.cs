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
        public string IP { get; set; }
        public string serverName { get; set; }
        public string guid { get; set; }
        public string mqIP { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public MessageSendRecieve(string IP, string name, string mq, string log, string pass)
        {
            this.IP = IP;
            this.serverName = name;
            this.guid = Guid.NewGuid().ToString();
            this.mqIP = mq;
            this.login = log;
            this.password = pass;
        }
    }
}
