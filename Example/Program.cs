using Core;
using Core.implementations;
using Core.interfaces;

namespace Example;

using System.Reflection;


public class Program
{
    
    static void Main(string[] args)
    {
        Tracer tracer = new Tracer();
        Threads threads = new Threads();
        ThreadsHolder.threads = threads;
        TestClass testClass = new TestClass(tracer);
        Thread thread = new Thread(testClass.DoSomething);
        Thread thread2 = new Thread(testClass.DoSomething);
        TraceResultThread traceResultThread = new TraceResultThread(thread,1);
        TraceResultThread traceResultThread2 = new TraceResultThread(thread2,2);
        threads.Methods.Add(traceResultThread);
        threads.Methods.Add(traceResultThread2);
        threads.Methods[0].Thread.Start();
        threads.Methods[1].Thread.Start();
        threads.Methods[0].Thread.Join();
        threads.Methods[1].Thread.Join();
        String converterName = "JSON";
        Assembly assembly = Assembly.LoadFrom($"D:\\Unik\\СПП\\Lab1\\Serialization\\" +
                                              $"{converterName}\\bin\\Debug\\net6.0\\{converterName}.dll");
        TraceResultSerializer traceResultSerializer = null;
        Type type = assembly.GetType($"{converterName}.{converterName}Converter");
        traceResultSerializer = (TraceResultSerializer)Activator.CreateInstance(type);
        Stream stream = Console.OpenStandardOutput();
        traceResultSerializer.Serialize(threads,stream);
        
        
    }
}