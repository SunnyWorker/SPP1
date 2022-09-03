namespace Lab1.implementations;

public class TestClass
{
    private Tracer _tracer;

    public TestClass()
    {
        _tracer = new Tracer();
    }

    public void DoSomething()
    {
        _tracer.StartTrace();
        Thread.Sleep(2000);
        _tracer.StopTrace();
    }
}