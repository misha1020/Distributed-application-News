using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageToSend msgToClient = new MessageToSend("25.46.156.10", "username", "password");
            DispatcherClient.SocketSend(msgToClient);
        }
    }
}
