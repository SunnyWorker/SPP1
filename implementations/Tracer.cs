using System.Diagnostics;
using Lab1.interfaces;

namespace Lab1.implementations;

public class Tracer : ITracer
{
    private Stopwatch _stopwatch;
    private TraceResult _traceResult;
    public void StartTrace()
    {
        _stopwatch.Start();
    }

    public Tracer()
    {
        _stopwatch = new Stopwatch();
        _traceResult = new TraceResult();
    }

    public void StopTrace()
    {
        _stopwatch.Stop();
        _traceResult.Time = (int)_stopwatch.Elapsed.TotalMilliseconds;
        _traceResult.Name = new StackTrace().GetFrame(0)?.GetMethod()?.Name;
        _traceResult.ClassName = GetType().Name;
        Console.WriteLine(_traceResult.Time);
    }

    public TraceResult GetTraceResult()
    {
        
        return _traceResult;
    }
}