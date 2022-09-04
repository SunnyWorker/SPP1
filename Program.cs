
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;
using Lab1;
using Lab1.entities;
using Lab1.implementations;


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
        ThreadWrapper threadWrapper = new ThreadWrapper(thread,1);
        threads.threads.Add(threadWrapper);
        threads.threads[0].Thread.Start();
        threads.threads[0].Thread.Join();
        Console.WriteLine(JsonValue.Parse(JsonSerializer.Serialize(threads)));
    }
}
