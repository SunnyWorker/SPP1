using System.Reflection;
using System.Text.Json.Serialization;

namespace Lab1.implementations;

public class ThreadWrapper
{
    [field: NonSerialized]
    public Thread Thread;
    [field: NonSerialized]
    public int TimeInt;

    public ThreadWrapper(Thread thread, int id)
    {
        Thread = thread;
        Thread.Name = id.ToString();
        Methods = new List<TraceResult>();
    }

    [JsonPropertyName("id")]
    public string Id { get => Thread.Name; }

    [JsonPropertyName("time")]
    public string Time
    {
        get => String.Format("{0}ms",TimeInt);
    }

    [JsonPropertyName("methods")]
    public List<TraceResult> Methods { get; set; }
}