using System.Collections.Concurrent;
using System.Diagnostics;
using Core.interfaces;

namespace Core.implementations;

public class Tracer : ITracer
{
    public ConcurrentDictionary<Thread, Stack<InfoClock>> ThreadInfoDictionary
    {
        get;
    }

    public void StartTrace()
    {
        StackTrace stackTrace = new StackTrace();
        List<MethodInfo> traceResultMethodsList = new List<MethodInfo>();
        MethodInfo methodInfo = new MethodInfo(stackTrace.GetFrame(1)?.GetMethod()?.Name,
            stackTrace.GetFrame(1)?.GetMethod()?.ReflectedType.Name,
            traceResultMethodsList);
        Stopwatch stopwatch = new Stopwatch();
        InfoClock infoClock = new InfoClock(stopwatch, methodInfo);
        InfoClock prevInfoClock = ThreadInfoDictionary[Thread.CurrentThread].Peek();
        prevInfoClock.Info.Methods.Add(methodInfo);
        ThreadInfoDictionary[Thread.CurrentThread].Push(infoClock);
        stopwatch.Start();
    }

    public Tracer()
    {
        ThreadInfoDictionary = new ConcurrentDictionary<Thread, Stack<InfoClock>>();
    }

    public void StopTrace()
    {
        InfoClock currentInfoClock = ThreadInfoDictionary[Thread.CurrentThread].Pop();
        Stopwatch currentStopwatch = currentInfoClock.Stopwatch;
        currentInfoClock.Stopwatch.Stop();
        currentInfoClock.Info.Time = $"{(int)currentStopwatch.Elapsed.TotalMilliseconds}ms";
        if (ThreadInfoDictionary[Thread.CurrentThread].Count == 1)
        {
            ThreadInfo threadInfo = (ThreadInfo)ThreadInfoDictionary[Thread.CurrentThread].Peek().Info;
            threadInfo.TimeInt += (int) currentStopwatch.Elapsed.TotalMilliseconds;
        }

    }

    public TraceResult GetTraceResult()
    {
        List<ThreadInfo> traceResultThreadList = new List<ThreadInfo>();
        foreach (var keyValuePair in ThreadInfoDictionary)
        {
            traceResultThreadList.Add((ThreadInfo)keyValuePair.Value.Peek().Info);
        }

        TraceResult traceResult = new TraceResult(traceResultThreadList);
        return traceResult;
    }
}