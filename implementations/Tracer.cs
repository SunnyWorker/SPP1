using System.Diagnostics;
using Lab1.interfaces;

namespace Lab1.implementations;

public class Tracer : ITracer
{
    private Stopwatch _stopwatch;
    private TraceResult _traceResult;
    
    public void StartTrace()
    {
        _traceResult.Name = new StackTrace().GetFrame(1)?.GetMethod()?.Name;
        _traceResult.ClassName = new StackTrace().GetFrame(1)?.GetMethod()?.ReflectedType.Name;
        _traceResult.Methods = new List<TraceResult>();
        Console.WriteLine(_traceResult.Name);
        Console.WriteLine(_traceResult.ClassName);
        int threadIndex = int.Parse(Thread.CurrentThread.Name)-1;
        List<TraceResult> traceResults = Program.threads.threads[threadIndex].Methods;
        StackTrace stackTrace = new StackTrace();
        for (int i = stackTrace.FrameCount-2; i > 1; i--)
        {
            String methodName = stackTrace.GetFrame(i).GetMethod().Name;
        
            for (int j = 0; j < traceResults.Count; j++)
            {
                if (traceResults[j].Name.Equals(methodName))
                {
                    traceResults = traceResults[j].Methods;
                    break;
                }
            }
        
        }
        
        traceResults.Add(GetTraceResult());
        
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
        
        int threadIndex = int.Parse(Thread.CurrentThread.Name)-1;
        
        List<TraceResult> traceResults = Program.threads.threads[threadIndex].Methods;
        StackTrace stackTrace = new StackTrace();
        if (stackTrace.FrameCount == 3) Program.threads.threads[threadIndex].TimeInt += _traceResult.Time;
        for (int i = stackTrace.FrameCount-2; i > 1; i--)
        {
            String methodName = stackTrace.GetFrame(i).GetMethod().Name;
        
            for (int j = 0; j < traceResults.Count; j++)
            {
                if (traceResults[j].Name.Equals(methodName))
                {
                    traceResults = traceResults[j].Methods;
                    break;
                }
            }
        
        }
        TraceResult helpTraceResult = traceResults[^1];
        helpTraceResult.Time = _traceResult.Time;
        traceResults[^1] = helpTraceResult;

    }

    public TraceResult GetTraceResult()
    {
        return _traceResult;
    }
}