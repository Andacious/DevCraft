using System;
using System.Diagnostics;

namespace DevCraft.Core.Process
{
    public interface IProcess
    {
        event DataReceivedEventHandler StandardOutput;
        event DataReceivedEventHandler ErrorOutput;
        event EventHandler Exited;
        bool IsRunning { get; }
        void Start();
        bool Input(string input);
    }
}