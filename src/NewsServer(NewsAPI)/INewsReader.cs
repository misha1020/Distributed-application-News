using System;
using System.Timers;
using MessageSendServe;

namespace NewsServer
{
    public delegate void NewsReceivedHandler(Article message);

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
