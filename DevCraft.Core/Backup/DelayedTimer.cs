using System;
using System.Timers;

namespace DevCraft.Core.Backup
{
    /// <summary>
    /// Encapsulates a timer that can repeatedly fire on a specific interval and can delay
    /// starting said interval until the specified offset length has been reached.
    /// </summary>
    public sealed class DelayedTimer : IDisposable
    {
        private readonly Timer _startingOffsetTimer = new Timer();
        private readonly Timer _intervalTimer = new Timer();

        private readonly double _delay;
        private readonly double _interval;

        /// <summary>
        /// After the starting offset has elapsed, this fires once the each time the interval is reached.
        /// </summary>
        public event ElapsedEventHandler Elapsed;

        /// <summary>
        /// Creates a <see cref="DelayedTimer"/> with the specified <paramref name="interval"/> to fire repeatedly
        /// and the specified <paramref name="delay"/> to delay starting of the repeating interval.
        /// </summary>
        /// <param name="delay">The amount of time to wait (in milliseconds) before starting the interval timer.</param>
        /// <param name="interval">The amount of time to wait (in milliseconds) between intervals. </param>
        public DelayedTimer(double delay, double interval)
        {
            if (interval <= 0) throw new ArgumentOutOfRangeException("interval");

            _delay = delay;
            _interval = interval;
        }

        /// <summary>
        /// Starts the timer after waiting for the delay to elapse.
        /// </summary>
        public void Start()
        {
            _intervalTimer.Interval = _interval;
            _intervalTimer.Elapsed += Elapsed;

            if (_delay > 0)
            {
                _startingOffsetTimer.Interval = _delay;
                _startingOffsetTimer.Elapsed += StartingOffsetTimerElapsed;
                _startingOffsetTimer.Start();
            }
            else
            {
                _intervalTimer.Start();
            }
        }

        #region IDisposable implementation

        /// <summary>
        /// Stops all timers, unhooks all event handlers, and disposes all components
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DelayedTimer()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_startingOffsetTimer != null)
                {
                    _startingOffsetTimer.Stop();
                    _startingOffsetTimer.Elapsed -= StartingOffsetTimerElapsed;
                    _startingOffsetTimer.Dispose();
                }

                if (_intervalTimer != null)
                {
                    _intervalTimer.Stop();
                    _intervalTimer.Elapsed -= Elapsed;
                    _intervalTimer.Dispose();
                }
            }
        }

        #endregion

        private void StartingOffsetTimerElapsed(Object source, ElapsedEventArgs e)
        {
            // the offset timer only runs once to get to the correct starting time
            _startingOffsetTimer.Stop();

            // once the correct starting time ahs been reached, start the interval timer
            _intervalTimer.Start();
        }
    }
}