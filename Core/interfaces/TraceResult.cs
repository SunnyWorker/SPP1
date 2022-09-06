using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core.implementations;
using YamlDotNet.Serialization;

namespace Core.interfaces;

[XmlInclude(typeof(TraceResultThread)), XmlInclude(typeof(TraceResultMethods)), XmlInclude(typeof(Threads))]
[XmlRoot("root")]
public class TraceResult
{
    [field: NonSerialized]
    [XmlIgnore]
    [JsonIgnore]
    [YamlIgnore]
    public int TimeInt
    {
        get;
        set;
    }

    [JsonPropertyName("time")]
    [XmlAttribute("time")]
    [YamlMember(Alias = "time", Order = 3)]
    [JsonPropertyOrder(3)]
    public virtual string? Time
    {
        get => $"{TimeInt}ms";
    }
    


}