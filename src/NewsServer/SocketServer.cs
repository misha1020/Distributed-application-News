﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MessageSendServe;

namespace NewsServer
{
    class SocketServer
    {
        private static int portPingServers = Convert.ToInt32(ConfigManager.Get("portPingServers"));
        private static int portDispatcherServer = Convert.ToInt32(ConfigManager.Get("portDispatcherServer"));
        
        public static void SendMsg<T>(Socket handler, T msg)
        {
            byte[] byteSet = BinFormatter.ToBytes<T>(msg);
            handler.Send(BinFormatter.ToBytes<int>(byteSet.Length));
            handler.Send(byteSet);
        }

        public static void SocketSend(MessageSendRecieve msg, string ip)
        {
            try
            {
                IPAddress ipAddr = IPAddress.Parse(ip);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, portDispatcherServer);
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ipEndPoint);

                SendMsg<MessageSendRecieve>(sender, msg);

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                Console.WriteLine("Подключено");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void pingReply()
        {
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Bind(new IPEndPoint(IPAddress.Any, portPingServers));
            sender.Listen(10);
            while (true)
            {
                try
                {
                    Socket receiver = sender.Accept();
                    Byte[] buf = new Byte[1];
                    receiver.Receive(buf);
                    receiver.Send(buf);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " in " + ex.Source);
                }
            }
        }
    }
}
