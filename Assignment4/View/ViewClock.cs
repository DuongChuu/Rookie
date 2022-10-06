using System;

namespace Assginment4
{
    public class ViewClock
    {
        public void Subcribe(Clock clock)
        {
            clock.clockTick += new Clock.clockTickHandler(ShowClock);
        }
        public void ShowClock(object clock, ClockEventArgs clockEventArgs)
        {
            Console.WriteLine(
                $"{clockEventArgs.hour} :{clockEventArgs.minute} :{clockEventArgs.second}"
                );
        }
    }
}