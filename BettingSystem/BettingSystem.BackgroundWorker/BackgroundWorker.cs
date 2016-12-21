using System;
using System.Threading;

namespace BettingSystem.BackgroundWorker
{
    public static class BackgroundWorker
    {
        public static void DoWork(TimerCallback action, object state, TimeSpan dueTime, TimeSpan interval)
        {
            var timer = new Timer(action, state, dueTime, interval);
        }
    }
}
