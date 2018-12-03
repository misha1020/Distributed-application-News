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
        public string mqIP { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string mqName { get; set; }

        public MessageSendRecieve(string IP, string mqIP, string mqName, string log, string pass)
        {
            this.IP = IP;
            this.mqName = mqName;
            this.mqIP = mqIP;
            this.login = log;
            this.password = pass;
        }
    }
}
