using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageSendServe;

namespace Client
{

    class SocketClient
    {
        private static int portPingServers = Convert.ToInt32(ConfigManager.Get("portPingServers"));
        private static int portDispatcherClient = Convert.ToInt32(ConfigManager.Get("portDispatcherClient"));

        public static T ReceiveMsg<T>(Socket receiver)
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
            if (bytesRec != 0)
                return BinFormatter.FromBytes<T>(bytes);
            else
                throw new FormatException("Серверов нет");
        }

        public static MessageSendRecieve[] RecieveServersList()
        {
            MessageSendRecieve[] servers = null;
            try
            {
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, portDispatcherClient);
                Socket receiver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                receiver.Connect(ipEndPoint);

                try
                {
                    servers = ReceiveMsg<MessageSendRecieve[]>(receiver);
                }
                catch(FormatException ex)
                {
                    servers = new MessageSendRecieve[0];
                }
                receiver.Shutdown(SocketShutdown.Both);
                receiver.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return servers;
        }

        public static void PingServs(FormClient formClient)
        {
            Program.msgsWithHosts_Semaphore.WaitOne();
            List<MessageSendRecieve> msgsWithHosts = new List<MessageSendRecieve>();
            foreach (var host in Program.msgsWithHosts)
                msgsWithHosts.Add(host);
            Program.msgsWithHosts_Semaphore.Release();

            for (int i = 0; i < msgsWithHosts.Count; i++)
            {
                MessageSendRecieve host = msgsWithHosts[i];
                try
                {
                    IPAddress ipAddr = IPAddress.Parse(host.IP);
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, portPingServers);
                    Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sender.Connect(ipEndPoint);
                    Byte[] buf = new Byte[1];
                    sender.Send(buf);
                    sender.Receive(buf);
                    formClient.AppendColorList(host.guid, true);
                }
                catch (Exception ex)
                {
                    formClient.AppendColorList(host.guid, false);
                    formClient.AppendTextBox($"serv missed! {host.IP}");
                }
            }
        }
    }
}
