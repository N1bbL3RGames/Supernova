using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupernovaServer.EventArguments
{
    class NewPlayerEventArgs : EventArgs
    {
        public string Username { get; set; }
        public int UserID { get; set; }

        public NewPlayerEventArgs(string username, int userID)
        {
            Username = username;
            UserID = userID;
        }
    }
}
