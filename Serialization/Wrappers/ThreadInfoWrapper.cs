using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core;
using Core.implementations;
using YamlDotNet.Serialization;

namespace Wrappers;

public class ThreadInfoWrapper : InfoWrapper
{

    [JsonPropertyName("time")]
    [XmlAttribute("time")]
    [JsonPropertyOrder(2)]
    [YamlMember(Alias = "time", Order = 2)]
    public override String Time
    {
        get;
        set;
    }

    public ThreadInfoWrapper()
    {
    }

    [JsonPropertyName("id")]
    [XmlAttribute("id")]
    [JsonPropertyOrder(1)]
    [YamlMember(Alias = "id", Order = 1)]
    public String Id
    {
        get;
        set;
    }

    public ThreadInfoWrapper(string id, List<MethodInfo> methods, string time) : base(methods, time)
    {
        Id = id;
    }
}