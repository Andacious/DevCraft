using System;
using System.Threading;
using System.Windows.Forms;
using DevCraft.UI.Forms;

namespace DevCraft.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ThreadPool.SetMaxThreads(Environment.ProcessorCount, 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
