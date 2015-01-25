using DevCraft.Core.Backup.Schedules;
using DevCraft.Core.Server;
using DevCraft.Utility;
using System;
using System.IO;
using System.Threading;
using System.Timers;

namespace DevCraft.Core.Backup
{
    public sealed class BackupManager
    {
        private readonly IServerInstance _server;
        
        private DelayedTimer _backupTimer;

        public event EventHandler BackupStarting;
        public event EventHandler BackupCompleted;
        public event EventHandler BackupFailed;

        public BackupManager(IServerInstance server)
        {
            if (server == null) throw new ArgumentNullException("server");

            _server = server;
        }

        public void RemoveOldBackups(string backupsPath, double daysToKeep)
        {
            var backupDef = new BackupRemovalDefinition { BackupsPath = backupsPath, DaysToKeep = daysToKeep };

            ThreadPool.QueueUserWorkItem(RemoveOldBackups_Worker, backupDef);
        }

        public void Backup()
        {
            if (_server == null
                || _server.BackupFolder == null
                || _server.ServerFolder == null)
            {
                return;
            }

            string currentDate = DateTime.Now.ToString("MM.dd.yyyy_HH.mm.ss");
            string levelName = _server.Name ?? string.Empty;
            string backupFolder = _server.BackupFolder;
            string serverFolder = _server.ServerFolder;

            try
            {
                //_server.Display("[DevCraft]: Performing map backup...");
                OnBackupStarting(EventArgs.Empty);

                _server.Input(Commands.SaveAll);
                _server.Input(Commands.SaveOff);

                string sourceDirectory = Path.Combine(serverFolder, levelName);
                string backupDirectory = Path.Combine(backupFolder, levelName + " - " + currentDate);

                DirectoryHelper.Mirror(sourceDirectory, backupDirectory);

                _server.Input(Commands.SaveOn);
                _server.Display("[DevCraft]: Backup complete.");
                OnBackupCompleted(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                _server.Input(Commands.SaveOn);
                _server.Display("[DevCraft]: Backup failed: " + ex.Message);
                OnBackupFailed(EventArgs.Empty);
            }
            finally
            {
                RemoveOldBackups(backupFolder, 5);
            }
        }

        public void InitializeBackups(ISchedule schedule)
        {
            double offset;
            double backupInterval = schedule.GetInterval(out offset);

            _backupTimer = new DelayedTimer(offset, backupInterval);
            _backupTimer.Elapsed += BackupFired;
            _backupTimer.Start();
        }

        private void OnBackupStarting(EventArgs e)
        {
            if (BackupStarting != null)
            {
                BackupStarting(this, e);
            }
        }

        private void OnBackupCompleted(EventArgs e)
        {
            if (BackupCompleted != null)
            {
                BackupCompleted(this, e);
            }
        }

        private void OnBackupFailed(EventArgs e)
        {
            if (BackupFailed != null)
            {
                BackupFailed(this, e);
            }
        }

        private void BackupFired(object source, ElapsedEventArgs e)
        {
            Backup();
        }

        private void RemoveOldBackups_Worker(object o)
        {
            var backupDef = (BackupRemovalDefinition)o;
            var daysToKeep = DateTime.Now.Subtract(TimeSpan.FromDays(backupDef.DaysToKeep));

            DirectoryHelper.DeleteBefore(backupDef.BackupsPath, daysToKeep);
        }
    }
}