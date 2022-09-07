using System.Reflection;
using Core.implementations;
using Core.interfaces;


namespace Core.Tests;

[TestClass]
public class UnitTest1
{
    private Tracer _tracer;
    private TraceResult _traceResult;
    [TestInitialize]
    public void Initialization()
    {
        // _traceResult = new TraceResult();
        // _tracer = new Tracer();
        // ThreadsHolder.threads = _traceResult;
    }

    
    [TestMethod]
    public void YAMLConverterWorks()
    {

    }
}