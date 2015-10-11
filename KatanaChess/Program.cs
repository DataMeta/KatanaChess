using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatanaChess
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// This application is purely event based and as such,
        /// there is no code in main.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameDisplay());
        }
    }
}
