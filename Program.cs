
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;
using System.Xml.Serialization;
using Lab1;
using Lab1.implementations;
using Lab1.interfaces;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


class Program
{
    public static Threads threads
    {
        get;
        set;
    } 
    static void Main(string[] args)
    {
        threads = new Threads();
        Tracer tracer = new Tracer();
        TestClass testClass = new TestClass(tracer);
        Thread thread = new Thread(testClass.DoSomething);
        TraceResultThread traceResultThread = new TraceResultThread(thread,1);
        threads.Methods.Add(traceResultThread);
        threads.Methods[0].Thread.Start();
        threads.Methods[0].Thread.Join();
        TraceResult traceResult = threads;
    }
}
