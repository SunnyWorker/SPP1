using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core.interfaces;
using YamlDotNet.Serialization;

namespace Core.implementations;

public class TraceResultThread : TraceResult
{
    [JsonPropertyName("methods")]
    [JsonPropertyOrder(3)]
    [XmlElement(ElementName = "method")]
    [YamlMember(Alias = "methods", Order = 3)]
    public List<TraceResultMethods> Methods
    {
        get;
        set;
    }

    public TraceResultThread()
    {
    }

    public TraceResultThread(Thread thread, int id)
    {
        Thread = thread;
        Thread.Name = id.ToString();
        Methods = new List<TraceResultMethods>();
    }
    
    [JsonPropertyName("time")]
    [XmlAttribute("time")]
    [JsonPropertyOrder(2)]
    [YamlMember(Alias = "time", Order = 2)]
    public override string? Time { get => $"{TimeInt}ms"; }
    
    [JsonPropertyName("id")]
    [XmlAttribute("id")]
    [JsonPropertyOrder(1)]
    [YamlMember(Alias = "id", Order = 1)]
    public string Id
    {
        get => Thread.Name;
        set => Id = value;
    }
}