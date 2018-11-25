using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
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

    class DispatcherClient
    {

        public static void SendString(Socket handler, string msg)
        {
            byte[] byteSet = BinFormatter.ToBytes<string>(msg);
            handler.Send(BinFormatter.ToBytes<int>(byteSet.Length));
            handler.Send(byteSet);
        }

        public static void SocketSend(MessageToSend msg)
        {
            int port = 11000;
            try
            {
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sender.Bind(new IPEndPoint(IPAddress.Any, port));
                sender.Listen(10);
                Socket handler = sender.Accept();

                SendString(handler, msg.hostIP);
                SendString(handler, msg.login);
                SendString(handler, msg.password);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                Console.WriteLine("Данные отправлены");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
