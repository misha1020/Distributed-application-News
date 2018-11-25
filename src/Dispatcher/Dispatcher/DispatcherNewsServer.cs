using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
{
    class DispatcherNewsServer
    {
        public static string ReceiveString(Socket receiver)
        {
            byte[] length = new byte[256];
            receiver.Receive(length, 0, length.Length, SocketFlags.None);
            int bytesRec = BinFormatter.FromBytes<int>(length);
            byte[] bytes = new byte[bytesRec];

            int a = 0;
            int step = bytesRec;
            while (a < bytesRec)
            {
                if (a + step > bytesRec)
                    step = bytesRec - a;
                a += receiver.Receive(bytes, a, step, SocketFlags.None);
            }
            return BinFormatter.FromBytes<string>(bytes);
        }

        public static void SocketRecieve()
        {
            int port = 11001;
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Bind(new IPEndPoint(IPAddress.Any, port));
            sender.Listen(10);

            while (true)
            {
                MessageSendRecieve msg = new MessageSendRecieve();
                try
                {
                    Socket receiver = sender.Accept();

                    msg.hostIP = ReceiveString(receiver);
                    msg.login = ReceiveString(receiver);
                    msg.password = ReceiveString(receiver);

                    receiver.Shutdown(SocketShutdown.Both);
                    receiver.Close();

                    Program.msgsWithHosts_Semaphore.WaitOne();
                    Program.msgsWithHosts.Add(msg);
                    Program.msgsWithHosts_Semaphore.Release();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            
        }
    }
}
