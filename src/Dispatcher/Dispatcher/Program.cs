using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatcher
{

    class Program
    {
        public static List<MessageSendRecieve> msgsWithHosts = new List<MessageSendRecieve>();
        public static Semaphore msgsWithHosts_Semaphore = new Semaphore(1, 1);

        static void Main(string[] args)
        {
            Console.WriteLine("Write 'Q' to finish");
            

            Thread ThreadFromServer = new Thread(new ThreadStart(DispatcherNewsServer.SocketRecieve));
            Thread ThreadToClient = new Thread(new ThreadStart(DispatcherClient.SocketSend));

            ThreadFromServer.Start();
            ThreadToClient.Start();
            string input = Console.ReadLine();
        }
    }
}
