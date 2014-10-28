using System;
using System.Diagnostics;
using System.IO;
using DevCraft.Core.Objects;

namespace DevCraft.Core.Logic
{
    public class MinecraftServerInstance : IServerInstance
    {
        private const string JAVA_EXE = "java.exe";
        private const string MINECRAFT_ARGUMENTS = "-Xmx1024M -Xms1024M -jar minecraft_server.jar nogui";
        private const string MESSAGE_FORMAT = "{0} {1}";
        private const string MESSAGE_FORMAT_EXTENDED = "{0} {1} {2}";

        private readonly string _serverFolder;

        private StreamWriter _input;
        private Process _proc;
        private ServerProperties _properties;

        public string Name
        {
            get
            {
                return _properties["level-name"] ?? string.Empty;
            }
        }

        public event DataReceivedEventHandler ServerOutput;
        public event EventHandler DevCraftOutput;

        public string BackupFolder { get; set; }

        public string ServerFolder
        {
            get { return _serverFolder; }
        }

        public bool IsRunning
        {
            get
            {
                return null != _proc;
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
            bool sentInput = false;

            if (IsRunning && _input != null && !string.IsNullOrWhiteSpace(input))
            {
                _input.WriteLine(input);
                _input.Flush();

                sentInput = true;
            }

            return sentInput;
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
            try
            {
                WriteDevCraftOutput(Resources.Starting);

                _proc = new Process
                {
                    StartInfo =
                    {
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        RedirectStandardInput = true,
                        UseShellExecute = false,
                        WorkingDirectory = _serverFolder,
                        FileName = JAVA_EXE,
                        Arguments = MINECRAFT_ARGUMENTS
                    },
                    EnableRaisingEvents = true
                };

                _proc.Exited += ExitHandler;
                _proc.OutputDataReceived += ServerOutput;
                _proc.ErrorDataReceived += ServerOutput;

                _proc.Start(); // gogo
                
                _proc.BeginOutputReadLine();
                _proc.BeginErrorReadLine();

                _input = _proc.StandardInput;

                WriteDevCraftOutput(Resources.Started);
            }
            catch (Exception ex)
            {
                WriteDevCraftOutput(Resources.ErrorStarting, ex.Message);
            }
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

        private void ExitHandler(Object sender, EventArgs args)
        {
            // unbind event handlers
            _proc.Exited -= ExitHandler;
            _proc.OutputDataReceived -= ServerOutput;
            _proc.ErrorDataReceived -= ServerOutput;

            // process cleanup
            _proc.CancelOutputRead();
            _proc.CancelErrorRead();
            _proc.StandardInput.Flush();
            _proc.Close();      // frees resources
            _proc.Dispose();    // release the freed resources
            _proc = null;       // null the proc co we know it has ended

            _input.Dispose();
            _input = null;

            WriteDevCraftOutput(Resources.Stopped);
        }

        private void WriteDevCraftOutput(string output)
        {
            DevCraftOutput(string.Format(MESSAGE_FORMAT, Resources.DevCraftOutputPrefix, output), EventArgs.Empty);
        }

        private void WriteDevCraftOutput(string output1, string output2)
        {
            DevCraftOutput(string.Format(MESSAGE_FORMAT_EXTENDED, Resources.DevCraftOutputPrefix, output1, output2), EventArgs.Empty);
        }
    }
}