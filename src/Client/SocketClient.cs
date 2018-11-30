using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageSerdServe;

namespace Client
{

    class SocketClient
    {

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
            return BinFormatter.FromBytes<T>(bytes);
        }

        public static string[] RecieveServersList()
        {
            int port = 11000;
            string[] guids = null;
            try
            {
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
                Socket receiver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                receiver.Connect(ipEndPoint);
                
                guids = ReceiveMsg<string[]>(receiver);
                receiver.Shutdown(SocketShutdown.Both);
                receiver.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return guids;
        }
        
        public static MessageSendRecieve SocketRecieve()
        {
            int port = 11005;
            MessageSendRecieve msg = new MessageSendRecieve();
            try
            {
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
                Socket receiver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                receiver.Connect(ipEndPoint);

                msg = ReceiveMsg<MessageSendRecieve>(receiver);

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
