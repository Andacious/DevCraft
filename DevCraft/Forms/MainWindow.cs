using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevCraft.Core;
using DevCraft.Core.Backup;
using DevCraft.Core.Server;
using DevCraft.UI.Properties;

namespace DevCraft.UI.Forms
{
    public partial class MainWindow : Form
    {
        delegate void SetTextCallback(string text);

        private string _serverFolder;
        private string _backupFolder;
        private IServerInstance _server;

        private bool ServerDirChosen
        {
            get
            {
                return !string.IsNullOrEmpty(_serverFolder);
            }
        }

        private bool BackupDirChosen
        {
            get
            {
                return !string.IsNullOrEmpty(_backupFolder);
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            // Set saved server directory if it contains minecraft_server.jar
            if (!string.IsNullOrWhiteSpace(Settings.Default.ServerDirectory))
            {
                if (File.Exists(Path.Combine(Settings.Default.ServerDirectory, "minecraft_server.jar")))
                {
                    _serverFolder = Settings.Default.ServerDirectory;
                    sDirLabel.Text = _serverFolder;
                }
            }

            // Set saved backup directory
            if (!string.IsNullOrWhiteSpace(Settings.Default.BackupDirectory))
            {
                _backupFolder = Settings.Default.BackupDirectory;
                bDirLabel.Text = _backupFolder;
            }

            // Set events
            FormClosing += DevCraft_GUI_FormClosing;
        }

        private void SetText(string text)
        {
            if (serverOutput.InvokeRequired)
            {
                SetTextCallback d = SetText;
                Invoke(d, new object[] { text });
            }
            else
            {
                serverOutput.AppendText(text + Environment.NewLine);
            }
        }

        // Collect the command output.
        private void OutputHandler(object sender, DataReceivedEventArgs outLine)
        {
            SetText(outLine.Data);
        }

        // collect devcraft output
        private void DevCraftOutputHandler(object sender, EventArgs e)
        {
            if (null != sender)
            {
                SetText(sender.ToString());
            }
        }

        private void sendCommand_Click(object sender, EventArgs e)
        {
            string input = inputBox.Text;

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (_server.Input(input))
                {
                    inputBox.Clear();
                }
                else
                {
                    SetText(string.Format("{0} {1}", Resources.DevCraftOutputPrefix, Resources.UnableToWriteInput));
                }
            }
        }

        private void StartServer()
        {
            _server = new MinecraftServerInstance(_serverFolder, _backupFolder);

            _server.ServerOutput += OutputHandler;
            _server.DevCraftOutput += DevCraftOutputHandler;

            _server.Start();

            serverName.Text = _server.Name;
        }

        private void StopServer()
        {
            if (_server.Stop())
            {
                _server.ServerOutput -= OutputHandler;
            }

            serverName.Text = string.Empty;
        }

        private void sDirButton_Click(object sender, EventArgs e)
        {
            bool validServerFolder = false;

            //// if the directory doesn't contain the server jar, pop the dialog box back up

            generalDirBrowser.Description = Resources.MinecraftServerDirectory;

            do
            {
                DialogResult result = generalDirBrowser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (File.Exists(Path.Combine(generalDirBrowser.SelectedPath, "minecraft_server.jar")))
                    {
                        _serverFolder = generalDirBrowser.SelectedPath;
                        Settings.Default.ServerDirectory = _serverFolder;
                        Settings.Default.Save();
                        sDirLabel.Text = _serverFolder;
                        validServerFolder = true;
                    }
                    else
                    {
                        MessageBox.Show("The specified Minecraft Server path must contain \"minecraft_server.jar\" to function properly.");
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            } while (!validServerFolder);
        }

        private void bDirButton_Click(object sender, EventArgs e)
        {
            generalDirBrowser.Description = Resources.MinecraftMapBackupDirectory;
            DialogResult result = generalDirBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                _backupFolder = generalDirBrowser.SelectedPath;
                Settings.Default.BackupDirectory = _backupFolder;
                Settings.Default.Save();
                bDirLabel.Text = _backupFolder;
            }
        }

        private void backupScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BackupScheduleWindow(_server).Show();
        }

        private void restartServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopServer();
            StartServer();
        }

        private void startServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ServerDirChosen && BackupDirChosen)
            {
                StartServer();
            }
            else
            {
                SetText("[DevCraft]: Cannot start Minecraft server:\r\n[DevCraft]: You must choose the location of your minecraft_server.jar and a location that you would like to backup your Minecraft worlds to.");
            }
        }

        private void removeOldBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BackupManager(_server).RemoveOldBackups(_backupFolder, 1);
        }

        private void forceBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BackupManager(_server).Backup();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("DevCraft {0}\r\nCopyright © 2011 - 2014 Andrew Ladwig", Assembly.GetExecutingAssembly().GetName().Version), "About");
        }

        private void stopServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void DevCraft_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !SafeExit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool SafeExit()
        {
            bool stopped = false;

            if (_server != null && _server.IsRunning)
            {
                if (MessageBox.Show(Resources.SafelyCloseContinue, Resources.ConfirmClose, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StopServer();
                    stopped = true;
                }
            }
            else
            {
                stopped = true;
            }

            return stopped;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ServerPropertiesWindow mp = new ServerPropertiesWindow(_serverFolder);
            mp.ShowDialog();
        }
    }
}