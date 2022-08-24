namespace SupernovaServer.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpServerOperations = new System.Windows.Forms.GroupBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.grpServerStatusLog = new System.Windows.Forms.GroupBox();
            this.dgvServerStatusLog = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpPlayers = new System.Windows.Forms.GroupBox();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.cmsPlayers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiKick = new System.Windows.Forms.ToolStripMenuItem();
            this.grpServerOperations.SuspendLayout();
            this.grpServerStatusLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerStatusLog)).BeginInit();
            this.grpPlayers.SuspendLayout();
            this.cmsPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpServerOperations
            // 
            this.grpServerOperations.Controls.Add(this.btnStopServer);
            this.grpServerOperations.Controls.Add(this.btnStartServer);
            this.grpServerOperations.Location = new System.Drawing.Point(12, 12);
            this.grpServerOperations.Name = "grpServerOperations";
            this.grpServerOperations.Size = new System.Drawing.Size(291, 50);
            this.grpServerOperations.TabIndex = 0;
            this.grpServerOperations.TabStop = false;
            this.grpServerOperations.Text = "Server Operations";
            // 
            // btnStopServer
            // 
            this.btnStopServer.Enabled = false;
            this.btnStopServer.Location = new System.Drawing.Point(148, 19);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(136, 23);
            this.btnStopServer.TabIndex = 1;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(6, 19);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(136, 23);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // grpServerStatusLog
            // 
            this.grpServerStatusLog.Controls.Add(this.dgvServerStatusLog);
            this.grpServerStatusLog.Location = new System.Drawing.Point(160, 68);
            this.grpServerStatusLog.Name = "grpServerStatusLog";
            this.grpServerStatusLog.Size = new System.Drawing.Size(620, 428);
            this.grpServerStatusLog.TabIndex = 2;
            this.grpServerStatusLog.TabStop = false;
            this.grpServerStatusLog.Text = "Server Status Log";
            // 
            // dgvServerStatusLog
            // 
            this.dgvServerStatusLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServerStatusLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.columnMessage});
            this.dgvServerStatusLog.Location = new System.Drawing.Point(6, 19);
            this.dgvServerStatusLog.Name = "dgvServerStatusLog";
            this.dgvServerStatusLog.Size = new System.Drawing.Size(608, 401);
            this.dgvServerStatusLog.TabIndex = 0;
            // 
            // columnID
            // 
            this.columnID.HeaderText = "ID";
            this.columnID.Name = "columnID";
            // 
            // columnMessage
            // 
            this.columnMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnMessage.HeaderText = "Message";
            this.columnMessage.Name = "columnMessage";
            // 
            // grpPlayers
            // 
            this.grpPlayers.Controls.Add(this.lstPlayers);
            this.grpPlayers.Location = new System.Drawing.Point(12, 68);
            this.grpPlayers.Name = "grpPlayers";
            this.grpPlayers.Size = new System.Drawing.Size(142, 428);
            this.grpPlayers.TabIndex = 3;
            this.grpPlayers.TabStop = false;
            this.grpPlayers.Text = "Players";
            // 
            // lstPlayers
            // 
            this.lstPlayers.ContextMenuStrip = this.cmsPlayers;
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(6, 19);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(130, 394);
            this.lstPlayers.TabIndex = 0;
            // 
            // cmsPlayers
            // 
            this.cmsPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiKick});
            this.cmsPlayers.Name = "cmsPlayers";
            this.cmsPlayers.Size = new System.Drawing.Size(97, 26);
            // 
            // cmsiKick
            // 
            this.cmsiKick.Name = "cmsiKick";
            this.cmsiKick.Size = new System.Drawing.Size(96, 22);
            this.cmsiKick.Text = "Kick";
            this.cmsiKick.Click += new System.EventHandler(this.kickToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 508);
            this.Controls.Add(this.grpPlayers);
            this.Controls.Add(this.grpServerStatusLog);
            this.Controls.Add(this.grpServerOperations);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.grpServerOperations.ResumeLayout(false);
            this.grpServerStatusLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerStatusLog)).EndInit();
            this.grpPlayers.ResumeLayout(false);
            this.cmsPlayers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpServerOperations;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.GroupBox grpServerStatusLog;
        private System.Windows.Forms.DataGridView dgvServerStatusLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMessage;
        private System.Windows.Forms.GroupBox grpPlayers;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.ContextMenuStrip cmsPlayers;
        private System.Windows.Forms.ToolStripMenuItem cmsiKick;
    }
}