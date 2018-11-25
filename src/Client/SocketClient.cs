using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    struct MessageToRecieve
    {
        public string hostIP;
        public string login;
        public string password;

        public MessageToRecieve(string ip, string log, string pass)
        {
            this.hostIP = ip;
            this.login = log;
            this.password = pass;
        }
    }

    class SocketClient
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

        public static MessageToRecieve SocketRecieve()
        {
            int port = 11000;
            MessageToRecieve msg = new MessageToRecieve();
            try
            {
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
                Socket receiver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                receiver.Connect(ipEndPoint);

                msg.hostIP = ReceiveString(receiver);
                msg.login = ReceiveString(receiver);
                msg.password = ReceiveString(receiver);

                receiver.Shutdown(SocketShutdown.Both);
                receiver.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return msg;
        }
    }
}
