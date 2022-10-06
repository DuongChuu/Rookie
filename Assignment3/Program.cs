using System;
namespace Assginment4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            ViewClock viewClock = new ViewClock();
            viewClock.Subcribe(clock);
            clock.Run();
        }
    }
}