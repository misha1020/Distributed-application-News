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

        public static void SendString(Socket handler, string msg)
        {
            byte[] byteSet = BinFormatter.ToBytes<string>(msg);
            handler.Send(BinFormatter.ToBytes<int>(byteSet.Length));
            handler.Send(byteSet);
        }

        public static void SocketSend(string ip, MessageToSend msg)
        {
            int port = 11001;
            try
            {
                IPAddress ipAddr = IPAddress.Parse(ip);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ipEndPoint);

                SendString(sender, msg.hostIP);
                SendString(sender, msg.login);
                SendString(sender, msg.password);

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                Console.WriteLine("Данные отправлены");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
