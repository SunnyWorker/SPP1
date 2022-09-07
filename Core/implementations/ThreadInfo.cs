using System.Diagnostics;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core.interfaces;
using YamlDotNet.Serialization;

namespace Core.implementations;

public class ThreadInfo : Info
{
    public ThreadInfo()
    {
    }

    public ThreadInfo(Tracer tracer, Thread thread, int id) : base()
    {
        tracer.ThreadInfoDictionary.TryAdd(thread, new Stack<InfoClock>());
        InfoClock infoClock = new InfoClock(null, this);
        tracer.ThreadInfoDictionary[thread].Push(infoClock);
        Id = id.ToString();
        Methods = new List<MethodInfo>();
    }
    
    [JsonPropertyName("time")]
    [XmlAttribute("time")]
    [JsonPropertyOrder(2)]
    [YamlMember(Alias = "time", Order = 2)]
    public override String Time { get => $"{TimeInt}ms"; }
    
    [JsonPropertyName("id")]
    [XmlAttribute("id")]
    [JsonPropertyOrder(1)]
    [YamlMember(Alias = "id", Order = 1)]
    public String Id
    {
        get;
        set;
    }

    [field: NonSerialized]
    [XmlIgnore]
    [JsonIgnore]
    [YamlIgnore]
    public int TimeInt
    {
        get;
        set;
    }
}