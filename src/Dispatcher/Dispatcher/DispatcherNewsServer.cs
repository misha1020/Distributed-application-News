using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MessageSerdServe;

namespace Dispatcher
{
    class DispatcherNewsServer
    {
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

                    msg.hostIP = RecieveMsg<string>(receiver);
                    msg.login = RecieveMsg<string>(receiver);
                    msg.password = RecieveMsg<string>(receiver);
                    msg.IP =(receiver.RemoteEndPoint as IPEndPoint).Address.ToString();

                    receiver.Shutdown(SocketShutdown.Both);
                    receiver.Close();

                    Program.msgsWithHosts_Semaphore.WaitOne();
                    Program.msgsWithHosts.Add(Guid.NewGuid().ToString(), msg);
                    Console.WriteLine("New server connected!");
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
            Dictionary<string, MessageSendRecieve> msgsWithHosts = new Dictionary<string, MessageSendRecieve>();
            foreach (var host in Program.msgsWithHosts)
                msgsWithHosts.Add(host.Key,host.Value);
            Program.msgsWithHosts_Semaphore.Release();


            foreach (var host in msgsWithHosts)
            {
                try
                {
                    //Console.WriteLine($"trying to ping {host.Value.IP}");
                    IPAddress ipAddr = IPAddress.Parse(host.Value.IP);
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11010);
                    Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sender.Connect(ipEndPoint);
                    Byte[] buf = new Byte[1];
                    sender.Send(buf);
                    sender.Receive(buf);
                }
                catch (Exception ex)
                {

                    Program.msgsWithHosts_Semaphore.WaitOne();
                    Program.msgsWithHosts.Remove(host.Key);
                    Program.msgsWithHosts_Semaphore.Release();

                    Console.WriteLine($"Host {host.Value.hostIP} doesn't answer");
                    //Console.WriteLine(ex.Message + " in " + ex.Source);
                }
            }
        }
    }

}
