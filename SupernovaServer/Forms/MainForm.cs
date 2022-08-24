using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupernovaServer.EventArguments;
using SupernovaServer.Managers;

namespace SupernovaServer.Forms
{
    public partial class MainForm : Form
    {
        private Task task;
        private Server server;
        private ManagerLogger managerLogger;
        private CancellationTokenSource cancellationTokenSource;

        public MainForm()
        {
            managerLogger = new ManagerLogger();
            managerLogger.NewLogMessageEvent += NewLogMessageEvent;

            server = new Server(managerLogger);
            server.newPlayer += NewPlayerEvent;

            InitializeComponent();
        }

        void NewPlayerEvent(object sender, NewPlayerEventArgs e)
        {
            if (InvokeRequired) 
            {
                Invoke(new EventHandler<NewPlayerEventArgs>(NewPlayerEvent), sender, e);
                return;
            }

            lstPlayers.Items.Add(e.Username); //User IDs are not implemented
        }

        void NewLogMessageEvent(object sender, LogMessageEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<LogMessageEventArgs>(NewLogMessageEvent), sender, e);
                return;
            }

            dgvServerStatusLog.Rows.Add(new[] { e.LogMessage.ID, e.LogMessage.Message });
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;

            cancellationTokenSource = new CancellationTokenSource();
            task = new Task(server.Run, cancellationTokenSource.Token);
            task.Start();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (task != null && cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                btnStartServer.Enabled = true;
                btnStopServer.Enabled = false;
            }
        }

        private void kickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedIndex == -1)
            {
                MessageBox.Show("Select a player first");
                return;
            }

            server.KickPlayer(lstPlayers.SelectedIndex);
            lstPlayers.Items.RemoveAt(lstPlayers.SelectedIndex);
        }
    }
}
