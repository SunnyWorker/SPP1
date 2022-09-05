using Core.interfaces;

namespace Core.implementations;

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
        Console.WriteLine("InnerMethod of Bar invoked!");
        Thread.Sleep(milliseconds);
        _tracer.StopTrace();
    }
}