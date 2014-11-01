using System;
using System.Diagnostics;

namespace DevCraft.Core.Server
{
    public interface IServerInstance
    {
       // Dictionary<string, string> Properties { get; }
        string BackupFolder { get; set; }
        string ServerFolder { get; }
        bool IsRunning { get; }
        string Name { get; }
        event DataReceivedEventHandler ServerOutput;
        event EventHandler DevCraftOutput;
        bool Input(string input);
        void Display(string input);
        void Start();
        bool Stop();
    }
}