using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageSerdServe;

namespace Client
{
    static class Program
    {
        public static Dictionary<string, MessageSendRecieve> msgsWithHosts = new Dictionary<string, MessageSendRecieve>();
        public static Semaphore msgsWithHosts_Semaphore = new Semaphore(1, 1);
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormClient());
        }
    }
}
