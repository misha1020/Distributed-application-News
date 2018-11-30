using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewsServer
{
    struct MessageToSend
    {
        public string hostIP;
        public string login;
        public string password;

        public MessageToSend(string ip, string log, string pass)
        {
            this.hostIP = ip;
            this.login = log;
            this.password = pass;
        }
    }

    class SocketServer
    {
        private static int pingReplyPort = Convert.ToInt32(ConfigManager.Get("pingPort"));

        public static void SendMsg<T>(Socket handler, T msg)
        {
            byte[] byteSet = BinFormatter.ToBytes<T>(msg);
            handler.Send(BinFormatter.ToBytes<int>(byteSet.Length));
            handler.Send(byteSet);
        }

        public static void SocketSend(MessageToSend msg, string ip)
        {
            int port = 11001;
            try
            {
                IPAddress ipAddr = IPAddress.Parse(ip);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ipEndPoint);

                SendMsg<string>(sender, msg.hostIP);
                SendMsg<string>(sender, msg.login);
                SendMsg<string>(sender, msg.password);

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                Console.WriteLine("Данные отправлены");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void pingReply()
        {
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Bind(new IPEndPoint(IPAddress.Any, pingReplyPort));
            sender.Listen(10);
            while (true)
            {
                try
                {
                    //Console.WriteLine("Waiting for ping");
                    Socket receiver = sender.Accept();
                    Byte[] buf = new Byte[1];
                    receiver.Receive(buf);
                    receiver.Send(buf);
                    //Console.WriteLine("Reply");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " in " + ex.Source);
                }
            }
        }
    }
}
