using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NewsServer
{
    public delegate void NewsReceivedHandler(string message);

    interface INewsReader : IDisposable
    {
        event NewsReceivedHandler NewsReceived;

        void Start();
        void Stop();
        void GetSomeNews();
        void GetAllNews();
        void GetNews(object sender = null, ElapsedEventArgs e = null);

    }
}
