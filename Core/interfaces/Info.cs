using System.Text.Json.Serialization;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace Core.interfaces;

public class Info
{
    [JsonPropertyName("methods")]
    [XmlElement("method")]
    [YamlMember(Alias = "methods", Order = 4)]
    [JsonPropertyOrder(4)]
    public List<MethodInfo> Methods
    {
        get;
        set;
    }
    
    [JsonPropertyName("time")]
    [XmlAttribute("time")]
    [YamlMember(Alias = "time", Order = 3)]
    [JsonPropertyOrder(3)]
    public virtual String Time { get; set; }
}