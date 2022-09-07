using System.Diagnostics;
using Core.interfaces;

namespace Core.implementations;

public class InfoClock
{

    public Info Info
    {
        get;
    }
    
    public Stopwatch Stopwatch
    {
        get;
    }

    public InfoClock(Stopwatch stopwatch, Info info)
    {
        Stopwatch = stopwatch;
        Info = info;
    }
}