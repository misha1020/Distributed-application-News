using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using MessageSendServe;

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
            Thread ThreadToClientSendList = new Thread(new ThreadStart(DispatcherClient.ServersListSend));
            System.Timers.Timer pingTimer = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
                pingTimer.Elapsed += Ping;
                pingTimer.AutoReset = true;
            pingTimer.Start();

            ThreadFromServer.Start();
            ThreadToClientSendList.Start();
            string input = Console.ReadLine();
        }

        private static void Ping(object sender, ElapsedEventArgs e)
        {
            DispatcherNewsServer.PingServs();
        }
    }
}
