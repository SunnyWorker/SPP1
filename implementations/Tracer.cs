using System.Diagnostics;
using Lab1.interfaces;

namespace Lab1.implementations;

public class Tracer : ITracer
{
    private Dictionary<Thread, Stack<Stopwatch>> _dictionaryStopwatch;
    private Dictionary<Thread, Stack<TraceResult>> _dictionaryTraceResult;

    public void StartTrace()
    {
        TraceResultMethods _traceResult = new TraceResultMethods();
        Stopwatch _stopwatch = new Stopwatch();
        _traceResult.Name = new StackTrace().GetFrame(1)?.GetMethod()?.Name;
        _traceResult.ClassName = new StackTrace().GetFrame(1)?.GetMethod()?.ReflectedType.Name;
        _traceResult.Methods = new List<TraceResultMethods>();
        int threadIndex = int.Parse(Thread.CurrentThread.Name)-1;
        List<TraceResultMethods> traceResults = Program.threads.Methods[threadIndex].Methods;
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
            _dictionaryTraceResult.Add(Thread.CurrentThread, new Stack<TraceResult>());
        }
        if (!_dictionaryStopwatch.ContainsKey(Thread.CurrentThread))
        {
            _dictionaryStopwatch.Add(Thread.CurrentThread, new Stack<Stopwatch>());
        }
        _dictionaryTraceResult[Thread.CurrentThread].Push(_traceResult);
        _dictionaryStopwatch[Thread.CurrentThread].Push(_stopwatch);
        _stopwatch.Start();
    }

    public Tracer()
    {
        _dictionaryStopwatch = new Dictionary<Thread, Stack<Stopwatch>>();
        _dictionaryTraceResult = new Dictionary<Thread, Stack<TraceResult>>();
    }

    public void StopTrace()
    {
        Stopwatch _stopwatch = _dictionaryStopwatch[Thread.CurrentThread].Pop();
        _stopwatch.Stop();
        TraceResult _traceResult = GetTraceResult();
        _traceResult.TimeInt = (int)_stopwatch.Elapsed.TotalMilliseconds;
        
        int threadIndex = int.Parse(Thread.CurrentThread.Name)-1;
        
        List<TraceResultMethods> traceResults = Program.threads.Methods[threadIndex].Methods;
        StackTrace stackTrace = new StackTrace();
        if (Program.threads.Methods[threadIndex].Methods.Contains(_traceResult)) Program.threads.Methods[threadIndex].TimeInt += _traceResult.TimeInt;
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