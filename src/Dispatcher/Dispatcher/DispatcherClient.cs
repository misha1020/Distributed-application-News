using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MessageSendServe;

namespace Dispatcher
{ 
    class DispatcherClient
    {

        public static void SendMsg<T>(Socket handler, T msg)
        {
            byte[] byteSet = BinFormatter.ToBytes<T>(msg);
            handler.Send(BinFormatter.ToBytes<int>(byteSet.Length));
            handler.Send(byteSet);
        }

        public static void ServersListSend()
        {
            int port = 11000;
            
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Bind(new IPEndPoint(IPAddress.Any, port));
            sender.Listen(10);
            while (true)
            {
                try
                {
                    Socket handler = sender.Accept();
                    Program.msgsWithHosts_Semaphore.WaitOne();
                    int serversCount = Program.msgsWithHosts.Count;
                    MessageSendRecieve[] servers = new MessageSendRecieve[serversCount]; 
                    if (serversCount != 0)
                    {
                        int i = 0;
                        foreach (var elem in Program.msgsWithHosts)
                        {
                            MessageSendRecieve msg = elem;
                            servers[i] = msg;
                            i++;
                        }
                        SendMsg<MessageSendRecieve[]>(handler, servers);
                        Console.WriteLine("Список серверов отпрален!");
                    }
                    Program.msgsWithHosts_Semaphore.Release();

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
