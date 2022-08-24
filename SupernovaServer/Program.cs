using System;
using System.Collections.Generic;
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

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainForm());
        }
    }
}