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
            System.Timers.Timer pingTimer = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
                pingTimer.Elapsed += Ping;
                pingTimer.AutoReset = true;
            pingTimer.Start();

            var ThreadFromServer_cts = new CancellationToken();
            Task.Run(() => DispatcherNewsServer.SocketRecieve(ThreadFromServer_cts));
            var ThreadToClientSendList_cts = new CancellationToken();
            Task.Run(() => DispatcherClient.ServersListSend(ThreadToClientSendList_cts));

            Console.WriteLine("Write \"Exit\" to finish");
            string input = Console.ReadLine();
            while (input.ToUpper() != "EXIT")
            {
                //if (input.ToUpper() == "GET")
                //{
                //    reader.GetNews();
                //}
                input = Console.ReadLine();
            }
        }

        private static void Ping(object sender, ElapsedEventArgs e)
        {
            DispatcherNewsServer.PingServs();
        }
    }
}
