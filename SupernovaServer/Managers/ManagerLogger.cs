using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupernovaServer.Utility;
using SupernovaServer.EventArguments;

namespace SupernovaServer
{
    class ManagerLogger
    {
        private List<LogMessage> logMessages;
        public event EventHandler<LogMessageEventArgs> NewLogMessageEvent;

        public ManagerLogger()
        {
            logMessages = new List<LogMessage>();
        }

        public void AddLogMessage(LogMessage logMessage)
        {
            logMessages.Add(logMessage);

            if (NewLogMessageEvent != null)
                NewLogMessageEvent(this, new LogMessageEventArgs(logMessage));
        }

        public void AddLogMessage(string id, string message)
        {
            AddLogMessage(new LogMessage { ID = id, Message = message});
        }
    }
}
