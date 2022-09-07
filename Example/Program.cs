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
        PluginHolder pluginHolder = new PluginHolder();
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
        
        TraceResult traceResult = tracer.GetTraceResult();
        traceResult = tracer.GetTraceResult();
        TraceResultSerializer traceResultSerializer = pluginHolder.GetPlugin("YAML");
        traceResultSerializer.Serialize(traceResult,Console.OpenStandardOutput());
    }
}