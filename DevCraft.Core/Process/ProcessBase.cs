using System;
using System.IO;

namespace DevCraft.Core.Process
{
    using System.Diagnostics;
    
    public abstract class ProcessBase : IProcess
    {
        private readonly string _executable;
        private readonly string _workingDirectory;

        private Process _proc;
        private StreamWriter _input;

        public event DataReceivedEventHandler StandardOutput;
        public event DataReceivedEventHandler ErrorOutput;
        public event EventHandler Exited;

        public bool IsRunning
        {
            get
            {
                return _proc != null;
            }
        }

        protected ProcessBase(string executable, string workingDirectory)
        {
            _executable = executable;
            _workingDirectory = workingDirectory;
        }

        public void Start()
        {
            try
            {
                _proc = new Process
                {
                    StartInfo =
                    {
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        RedirectStandardInput = true,
                        UseShellExecute = false,
                        WorkingDirectory = _workingDirectory,
                        FileName = _executable,
                        Arguments = GetArguments()
                    },
                    EnableRaisingEvents = true
                };

                _proc.Exited += InternalExitHandler;
                _proc.OutputDataReceived += StandardOutput;
                _proc.ErrorDataReceived += ErrorOutput;

                _proc.Start(); // gogo

                _proc.BeginOutputReadLine();
                _proc.BeginErrorReadLine();

                _input = _proc.StandardInput;

            }
            catch
            {
                OnExited(this);
            }
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

        protected abstract string GetArguments();

        /// <summary>
        /// Fires the <see cref="Exited"/> event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        protected void OnExited(object sender)
        {
            Exited(sender, EventArgs.Empty);
        }

        private void InternalExitHandler(object sender, EventArgs args)
        {
            // unbind event handlers
            _proc.Exited -= InternalExitHandler;
            _proc.OutputDataReceived -= StandardOutput;
            _proc.ErrorDataReceived -= ErrorOutput;

            // process cleanup
            _proc.CancelOutputRead();
            _proc.CancelErrorRead();
            _proc.StandardInput.Flush();
            _proc.Close();      // frees resources
            _proc.Dispose();    // release the freed resources
            _proc = null;       // null the proc co we know it has ended

            _input.Dispose();
            _input = null;

            OnExited(sender);
        }
    }
}