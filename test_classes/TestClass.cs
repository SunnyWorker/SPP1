using Lab1.interfaces;

namespace Lab1.implementations;

public class TestClass
{
    private ITracer _tracer;
    private Bar bar;

    public TestClass()
    {
    }

    public TestClass(ITracer tracer)
    {
        _tracer = tracer;
        bar = new Bar(tracer);
    }

    public void DoSomething()
    {
        _tracer.StartTrace();
        bar.InnerMethod(200);
        Thread.Sleep(2000);
        bar.InnerMethod(700);
        _tracer.StopTrace();
    }
}