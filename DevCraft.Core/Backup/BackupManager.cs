using DevCraft.Core.Backup.Schedules;
using DevCraft.Core.Server;
using DevCraft.Utility;
using System;
using System.IO;
using System.Threading;
using System.Timers;

namespace DevCraft.Core.Backup
{
    public class BackupManager
    {
        // TODO: remove static instances
        private static DelayedTimer _backupTimer;
        private static IServerInstance _server;

        public static void RemoveOldBackups(string backupsPath, double daysToKeep)
        {
            var backupDef = new BackupRemovalDefinition { BackupsPath = backupsPath, DaysToKeep = daysToKeep };
            ThreadPool.SetMaxThreads(2, 0);
            ThreadPool.QueueUserWorkItem(RemoveOldBackups_Worker, backupDef);
        }

        private static void RemoveOldBackups_Worker(object o)
        {
            var backupDef = (BackupRemovalDefinition)o;
            var daysToKeep = DateTime.Now.Subtract(TimeSpan.FromDays(backupDef.DaysToKeep));

            DirectoryHelper.DeleteBefore(backupDef.BackupsPath, daysToKeep);
        }

        public static void Backup(IServerInstance serverInstance)
        {
            if (serverInstance == null
                || serverInstance.BackupFolder == null
                || serverInstance.ServerFolder == null)
            {
                return;
            }

            string currentDate = DateTime.Now.ToString("MM.dd.yyyy_HH.mm.ss");
            string levelName = serverInstance.Name ?? string.Empty;
            string backupFolder = serverInstance.BackupFolder;
            string serverFolder = serverInstance.ServerFolder;

            try
            {
                serverInstance.Display("[DevCraft]: Performing map backup...");
                serverInstance.Input(Commands.SaveAll);
                serverInstance.Input(Commands.SaveOff);

                string sourceDirectory = Path.Combine(serverFolder, levelName);
                string backupDirectory = Path.Combine(backupFolder, levelName + " - " + currentDate);

                DirectoryHelper.Mirror(sourceDirectory, backupDirectory);

                serverInstance.Input(Commands.SaveOn);
                serverInstance.Display("[DevCraft]: Backup complete.");
            }
            catch (Exception ex)
            {
                // TODO: lordy this is bad
                try
                {
                    serverInstance.Input(Commands.SaveOn);
                    serverInstance.Display("[DevCraft]: Backup failed: " + ex.Message);
                }
                catch (Exception ex2)
                {
                    //SetText("[DevCraft]: Unable to back up world: " + ex2.Message);
                }
            }
            finally
            {
                RemoveOldBackups(backupFolder, 5);
            }
        }

        public static void InitializeBackups(ISchedule schedule, IServerInstance server)
        {
            _server = server;

            double offset;

            double backupInterval = schedule.GetInterval(out offset);

            _backupTimer = new DelayedTimer(offset, backupInterval);

            _backupTimer.Elapsed += BackupFired;

            _backupTimer.Start();
        }

        private static void BackupFired(Object source, ElapsedEventArgs e)
        {
            Backup(_server);
        }
    }
}