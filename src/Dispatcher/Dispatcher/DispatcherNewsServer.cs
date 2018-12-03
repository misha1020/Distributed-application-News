using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MessageSendServe;

namespace Dispatcher
{
    class DispatcherNewsServer
    {
        private static int portDispatcherServer = Convert.ToInt32(ConfigManager.Get("portDispatcherServer"));
        private static int portPingServers = Convert.ToInt32(ConfigManager.Get("portPingServers"));

        public static T RecieveMsg<T>(Socket receiver)
        {
            byte[] length = new byte[256];

            int c = 0;
            int step = 256;
            while (c < 256)
            {
                if (c + step > 256)
                    step = 256 - c;
                c += receiver.Receive(length, c, step, SocketFlags.None);
            }

            int bytesRec = BinFormatter.FromBytes<int>(length);
            byte[] bytes = new byte[bytesRec];

            int a = 0;
            step = bytesRec;
            while (a < bytesRec)
            {
                if (a + step > bytesRec)
                    step = bytesRec - a;
                a += receiver.Receive(bytes, a, step, SocketFlags.None);
            }
            return BinFormatter.FromBytes<T>(bytes);
        }

        public static async Task SocketRecieve(CancellationToken ct)
        {
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Bind(new IPEndPoint(IPAddress.Any, portDispatcherServer));
            sender.Listen(10);
            while (!ct.IsCancellationRequested)
            {
                MessageSendRecieve msg = new MessageSendRecieve();
                try
                {
                    Socket receiver = sender.Accept();
                    msg = RecieveMsg<MessageSendRecieve>(receiver);
                    msg.IP =(receiver.RemoteEndPoint as IPEndPoint).Address.ToString();


                    Program.msgsWithHosts_Semaphore.WaitOne();
                    bool nameRepeats = false;
                    for (int i = 0; i < Program.msgsWithHosts.Count && !nameRepeats; i++)
                        nameRepeats = Program.msgsWithHosts[i].mqName == msg.mqName;
                    Program.msgsWithHosts_Semaphore.Release();

                    if (!nameRepeats)
                        receiver.Send(BinFormatter.ToBytes<bool>(true));
                    else
                    {
                        Console.WriteLine($"Server {msg.mqIP} denied");
                        receiver.Send(BinFormatter.ToBytes<bool>(false));
                        receiver.Shutdown(SocketShutdown.Both);
                        receiver.Close();
                        break;
                    }

                    receiver.Shutdown(SocketShutdown.Both);
                    receiver.Close();

                    Program.msgsWithHosts_Semaphore.WaitOne();
                    Program.msgsWithHosts.Add(msg);
                    Console.WriteLine("New server connected");
                    Program.msgsWithHosts_Semaphore.Release();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public static void PingServs()
        {
            Program.msgsWithHosts_Semaphore.WaitOne();
            List<MessageSendRecieve> msgsWithHosts = new List<MessageSendRecieve>();
            foreach (var host in Program.msgsWithHosts)
                msgsWithHosts.Add(host);
            Program.msgsWithHosts_Semaphore.Release();

            foreach (var host in msgsWithHosts)
            {
                try
                {
                    IPAddress ipAddr = IPAddress.Parse(host.IP);
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, portPingServers);
                    Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sender.Connect(ipEndPoint);
                    Byte[] buf = new Byte[1];
                    sender.Send(buf);
                    sender.Receive(buf);
                }
                catch (Exception ex)
                {
                    Program.msgsWithHosts_Semaphore.WaitOne();
                    Program.msgsWithHosts.Remove(host);
                    Program.msgsWithHosts_Semaphore.Release();

                    Console.WriteLine($"Server {host.mqName} disconnected");
                }
            }
        }
    }

}
