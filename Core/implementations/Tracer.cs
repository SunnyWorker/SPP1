using System.Collections.Concurrent;
using System.Diagnostics;
using Core.interfaces;

namespace Core.implementations;

public class Tracer : ITracer
{
    private ConcurrentDictionary<Thread, Stack<Stopwatch>> _dictionaryStopwatch;
    private ConcurrentDictionary<Thread, Stack<TraceResult>> _dictionaryTraceResult;

    public void StartTrace()
    {
        TraceResultMethods _traceResult = new TraceResultMethods();
        Stopwatch _stopwatch = new Stopwatch();
        _traceResult.Name = new StackTrace().GetFrame(1)?.GetMethod()?.Name;
        _traceResult.ClassName = new StackTrace().GetFrame(1)?.GetMethod()?.ReflectedType.Name;
        _traceResult.Methods = new List<TraceResultMethods>();
        int threadIndex = int.Parse(Thread.CurrentThread.Name)-1;
        List<TraceResultMethods> traceResults = ThreadsHolder.threads.Methods[threadIndex].Methods;
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
        
        traceResults.Add(_traceResult);
        if (!_dictionaryTraceResult.ContainsKey(Thread.CurrentThread))
        {
            _dictionaryTraceResult.TryAdd(Thread.CurrentThread, new Stack<TraceResult>());
        }
        if (!_dictionaryStopwatch.ContainsKey(Thread.CurrentThread))
        {
            _dictionaryStopwatch.TryAdd(Thread.CurrentThread, new Stack<Stopwatch>());
        }
        _dictionaryTraceResult[Thread.CurrentThread].Push(_traceResult);
        _dictionaryStopwatch[Thread.CurrentThread].Push(_stopwatch);
        _stopwatch.Start();
    }

    public Tracer()
    {
        _dictionaryStopwatch = new ConcurrentDictionary<Thread, Stack<Stopwatch>>();
        _dictionaryTraceResult = new ConcurrentDictionary<Thread, Stack<TraceResult>>();
    }

    public void StopTrace()
    {
        Stopwatch _stopwatch = _dictionaryStopwatch[Thread.CurrentThread].Pop();
        _stopwatch.Stop();
        TraceResult _traceResult = GetTraceResult();
        _traceResult.TimeInt = (int)_stopwatch.Elapsed.TotalMilliseconds;
        
        int threadIndex = int.Parse(Thread.CurrentThread.Name)-1;
        
        List<TraceResultMethods> traceResults = ThreadsHolder.threads.Methods[threadIndex].Methods;
        StackTrace stackTrace = new StackTrace();
        if (ThreadsHolder.threads.Methods[threadIndex].Methods.Contains(_traceResult)) 
            ThreadsHolder.threads.Methods[threadIndex].TimeInt += _traceResult.TimeInt;
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
        TraceResultMethods helpTraceResult = traceResults[^1];
        helpTraceResult.TimeInt = _traceResult.TimeInt;
        traceResults[^1] = helpTraceResult;

    }

    public TraceResult GetTraceResult()
    {
        return _dictionaryTraceResult[Thread.CurrentThread].Pop();
    }
}