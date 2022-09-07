using System.Text.Json;
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
        TestClass testClass = new TestClass(tracer);
        Thread thread;
        // for (int i = 1; i < 3; i++)
        // {
            thread = new Thread(testClass.DoSomething);
            ThreadInfo threadInfo = new ThreadInfo(tracer,thread,1);
            thread.Start();
        //}

        foreach (var keyValuePair in tracer.ThreadInfoDictionary)
        {
            keyValuePair.Key.Join();
        }
        
        // String converterName = "JSON";
        // Assembly assembly = Assembly.LoadFrom($"D:\\Unik\\СПП\\Lab1\\Serialization\\" +
        //                                       $"{converterName}\\bin\\Debug\\net6.0\\{converterName}.dll");
        // TraceResultSerializer traceResultSerializer = null;
        // Type type = assembly.GetType($"{converterName}.{converterName}Converter");
        // traceResultSerializer = (TraceResultSerializer)Activator.CreateInstance(type);
        // traceResultSerializer.Serialize(traceResult,Console.OpenStandardOutput());
        
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            
        };
        JsonSerializer.Serialize<object>(Console.OpenStandardOutput(),tracer.GetTraceResult(),options);
        
    }
}