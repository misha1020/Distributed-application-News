using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
{ 
    class DispatcherClient
    {

        public static void SendString(Socket handler, string msg)
        {
            byte[] byteSet = BinFormatter.ToBytes<string>(msg);
            handler.Send(BinFormatter.ToBytes<int>(byteSet.Length));
            handler.Send(byteSet);
        }

        public static void SocketSend()
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
                    if (Program.msgsWithHosts.Count != 0)
                    {
                        MessageSendRecieve msg = Program.msgsWithHosts[0];

                        SendString(handler, msg.hostIP);
                        SendString(handler, msg.login);
                        SendString(handler, msg.password);
                        Console.WriteLine("Данные отправлены");
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
