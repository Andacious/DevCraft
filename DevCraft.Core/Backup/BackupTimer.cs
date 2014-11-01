using System;
using System.Timers;

namespace DevCraft.Core.Backup
{
    public sealed class BackupTimer : IDisposable
    {
        private readonly Timer _offsetTimer = new Timer();
        private readonly Timer _backupTimer = new Timer();

        private readonly double _offsetAmount;
        private readonly double _backupInterval;

        public event ElapsedEventHandler FireBackup;

        public BackupTimer(double offsetAmount, double backupInterval)
        {
            _offsetAmount = offsetAmount;
            _backupInterval = backupInterval;
        }

        public void Start()
        {
            _backupTimer.Interval = _backupInterval;
            _backupTimer.Elapsed += FireBackup;

            if (_offsetAmount > 0)
            {
                _offsetTimer.Interval = _offsetAmount;
                _offsetTimer.Elapsed += offsetTimer_Elapsed;
                _offsetTimer.Start();
            }
            else
            {
                _backupTimer.Start();
            }
        }

        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BackupTimer()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_offsetTimer != null)
                {
                    _offsetTimer.Stop();
                    _offsetTimer.Elapsed -= offsetTimer_Elapsed;
                    _offsetTimer.Dispose();
                }

                if (_backupTimer != null)
                {
                    _backupTimer.Stop();
                    _backupTimer.Elapsed -= FireBackup;
                    _backupTimer.Dispose();
                }
            }
        }

        #endregion

        private void offsetTimer_Elapsed(Object source, ElapsedEventArgs e)
        {
            _offsetTimer.Stop();

            _backupTimer.Start();
        }
    }
}