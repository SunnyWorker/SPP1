using System.Reflection;
using Core.implementations;
using Core.interfaces;


namespace Core.Tests;

[TestClass]
public class UnitTest1
{
    private Tracer _tracer;
    private Threads _threads;
    [TestInitialize]
    public void Initialization()
    {
        _threads = new Threads();
        _tracer = new Tracer();
        ThreadsHolder.threads = _threads;


    }
    
    [TestMethod]
    public void TraceResultMoreThan2900()
    {
        TestClass testClass = new TestClass(_tracer);
        Thread thread = new Thread(testClass.DoSomething);
        TraceResultThread traceResultThread = new TraceResultThread(thread,1);
        _threads.Methods.Add(traceResultThread);
        _threads.Methods[0].Thread.Start();
        _threads.Methods[0].Thread.Join();
        Assert.IsTrue(_threads.Methods[0].TimeInt>2900);
    }
    
    [TestMethod]
    public void YAMLConverterWorks()
    {
        TestClass testClass = new TestClass(_tracer);
        Thread thread = new Thread(testClass.DoSomething);
        TraceResultThread traceResultThread = new TraceResultThread(thread,1);
        _threads.Methods.Add(traceResultThread);
        _threads.Methods[0].Thread.Start();
        _threads.Methods[0].Thread.Join();
        String converterName = "YAML";
        Assembly assembly = Assembly.LoadFrom($"D:\\Unik\\СПП\\Lab1\\Serialization\\" +
                                              $"{converterName}\\bin\\Debug\\net6.0\\{converterName}.dll");
        TraceResultSerializer traceResultSerializer = null;
        Type type = assembly.GetType($"{converterName}.{converterName}Converter");
        traceResultSerializer = (TraceResultSerializer)Activator.CreateInstance(type);
        Stream stream = Console.OpenStandardOutput();
        traceResultSerializer.Serialize(_threads,stream);
    }
}