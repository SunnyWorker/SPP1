using Lab1.interfaces;

namespace Lab1.implementations;

public class TestClass
{
    private ITracer _tracer;
    private Bar bar;

    public TestClass(ITracer tracer)
    {
        _tracer = tracer;
        bar = new Bar(tracer);
    }

    public void DoSomething()
    {
        _tracer.StartTrace();
        bar.InnerMethod();
        Thread.Sleep(2000);
        _tracer.StopTrace();
    }
}