using Lab1.interfaces;

namespace Lab1.implementations;

public class Bar
{
    private ITracer _tracer;

    public Bar(ITracer tracer)
    {
        _tracer = tracer;
    }

    public void InnerMethod(int milliseconds)
    {
        _tracer.StartTrace();
        Thread.Sleep(milliseconds);
        _tracer.StopTrace();
    }
}