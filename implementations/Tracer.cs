using System.Diagnostics;
using Lab1.interfaces;

namespace Lab1.implementations;

public class Tracer : ITracer
{
    public void StartTrace()
    {
        throw new NotImplementedException();
    }

    public void StopTrace()
    {
        throw new NotImplementedException();
    }

    public TraceResult GetTraceResult()
    {
        return new TraceResult();
    }
}