using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using DevCraft.Core.Objects;
using DevCraft.Core.Schedules;

namespace DevCraft.Core.Logic
{
    public class BackupManager
    {
        private static BackupTimer _backupTimer;

        private static IServerInstance _server;

        public static BackupTimer BackupTimer
        {
            get
            {
                return _backupTimer;
            }
        }

        public static void RemoveOldBackups(string backupsPath, double daysToKeep)
        {
            var backupDef = new BackupRemovalDefinition { BackupsPath = backupsPath, DaysToKeep = daysToKeep };
            ThreadPool.SetMaxThreads(2, 0);
            ThreadPool.QueueUserWorkItem(RemoveOldBackups_Worker, backupDef);
        }

        private static void RemoveOldBackups_Worker(object o)
        {
            var backupDef = (BackupRemovalDefinition)o;

            string backupsPath = backupDef.BackupsPath;
            double daysToKeep = backupDef.DaysToKeep;

            if (!Directory.Exists(backupsPath))
            {
                return;
            }

            List<string> directories = Directory.GetDirectories(backupsPath, "*", SearchOption.TopDirectoryOnly).ToList();

            DateTime minDateAllowed = DateTime.Now.Subtract(TimeSpan.FromDays(daysToKeep));

            foreach (string d in directories)
            {
                DateTime creationDate = Directory.GetCreationTime(d);

                if (creationDate < minDateAllowed)
                {
                    Directory.Delete(d, true);
                }
            }
        }

        public static void Backup(IServerInstance serverInstance)
        {
            string currentDate = DateTime.Now.ToString("MM.dd.yyyy_hh.mm.ss");
            string levelName = serverInstance.Name;
            string backupFolder = serverInstance.BackupFolder;
            string serverFolder = serverInstance.ServerFolder;

            try
            {
                serverInstance.Display("[DevCraft]: Performing map backup...");
                serverInstance.Input(Commands.SaveAll);
                serverInstance.Input(Commands.SaveOff);

                if (!Directory.Exists(backupFolder))
                {
                    Directory.CreateDirectory(backupFolder);
                }

                string backupDirectory = Path.Combine(backupFolder, levelName + " - " + currentDate);
                Directory.CreateDirectory(backupDirectory);

                string sourceDirectory = Path.Combine(serverFolder, levelName);

                //// Have robocopy do all the heavy lifting :) (if you dont have robocopy, piss off)
                Process robocopy = new Process
                {
                    StartInfo =
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        FileName = "Robocopy.exe",
                        Arguments = String.Format("\"{0}\" \"{1}\" /MIR", sourceDirectory, backupDirectory)
                    }
                };

                robocopy.Start();
                robocopy.WaitForExit();
                robocopy.Close();
                robocopy.Dispose();

                // test compression
                //CompressionManager.Compress(backupDirectory);


                serverInstance.Input(Commands.SaveOn);
                serverInstance.Display("[DevCraft]: Backup complete.");
            }
            catch (Exception ex)
            {
                // thats right...a nested try catch. I'll figure out the actual exceptions later, thank you...
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

            _backupTimer = new BackupTimer(offset, backupInterval);

            _backupTimer.FireBackup += BackupFired;

            _backupTimer.Start();
        }

        private static void BackupFired(Object source, ElapsedEventArgs e)
        {
            Backup(_server);
        }
    }
}