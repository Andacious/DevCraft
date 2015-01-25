using System;
using System.Diagnostics;
using DevCraft.Core.Process;

namespace DevCraft.Core.Server
{
    public class MinecraftServerInstance : IServerInstance
    {
        private const string MESSAGE_FORMAT = "{0} {1}";
        private const string MESSAGE_FORMAT_EXTENDED = "{0} {1} {2}";

        private readonly string _serverFolder;

        private IProcess _proc;
        private ServerProperties _properties;

        public event DataReceivedEventHandler ServerOutput;
        public event EventHandler DevCraftOutput;

        public string Name
        {
            get
            {
                return _properties["level-name"] ?? string.Empty;
            }
        }

        public string BackupFolder { get; set; }

        public string ServerFolder
        {
            get { return _serverFolder; }
        }

        public bool IsRunning
        {
            get
            {
                return _proc != null;
            }
        }

        public MinecraftServerInstance(string serverFolder)
        {
            _serverFolder = serverFolder;
            _properties = new ServerProperties(_serverFolder);
        }

        public MinecraftServerInstance(string serverFolder, string backupFolder)
            : this(serverFolder)
        {
            BackupFolder = backupFolder;
        }

        public bool Input(string input)
        {
            if (IsRunning)
            {
                return _proc.Input(input);
            }

            return false;
        }

        public void Display(string input)
        {
            if (input != null)
            {
                Input(string.Format("{0} {1}", Commands.Say, input));
            }
        }

        public void Start()
        {
            WriteDevCraftOutput(Resources.Starting);

            _proc = new JavaProcess("minecraft_server.jar", _serverFolder);
            _proc.ErrorOutput += ServerOutput;
            _proc.StandardOutput += ServerOutput;
            _proc.Exited += Exited;

            _proc.Start();

            WriteDevCraftOutput(Resources.Started);
        }

        public bool Stop()
        {
            bool stopped = false;

            try
            {
                if (IsRunning)
                {
                    WriteDevCraftOutput(Resources.Stopping);
                    Input(Commands.Stop);
                    _properties = null;

                    stopped = true;
                }
                
            }
            catch (Exception ex)
            {
                WriteDevCraftOutput(Resources.ErrorStopping, ex.Message);
            }

            return stopped;
        }

        private void WriteDevCraftOutput(string output)
        {
            DevCraftOutput(string.Format(MESSAGE_FORMAT, Resources.DevCraftOutputPrefix, output), EventArgs.Empty);
        }

        private void WriteDevCraftOutput(string output1, string output2)
        {
            DevCraftOutput(string.Format(MESSAGE_FORMAT_EXTENDED, Resources.DevCraftOutputPrefix, output1, output2), EventArgs.Empty);
        }

        private void Exited(object sender, EventArgs e)
        {
            WriteDevCraftOutput(Resources.Stopped);
        }
    }
}