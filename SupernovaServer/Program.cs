using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using SupernovaLibrary;
using System.Net.Mime;
using System.Windows.Forms;
using SupernovaServer.Forms;

namespace SupernovaServer
{
    static class Program 
    {
        [STAThread]

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainForm());
        }
    }
}