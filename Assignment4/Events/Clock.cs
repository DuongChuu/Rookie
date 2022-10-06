using System;

namespace Assginment4
{
    public class Clock
    {
        private int _second;
        public delegate void clockTickHandler(object clock, ClockEventArgs clockEventArgs);
        public event clockTickHandler? clockTick;
        protected void Ontick(object clock, ClockEventArgs clockEventArgs)
        {
            if (clockTick != null)
            {
                clockTick(clock, clockEventArgs);

            }
        }
        public void Run()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                var time = DateTime.Now;
                if (time.Second != _second)
                {
                    var clockEventArgs = new ClockEventArgs(time.Hour, time.Minute, time.Second);
                    Ontick(this, clockEventArgs);
                }
            }
        }
    }
}