using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core;
using YamlDotNet.Serialization;

namespace Wrappers;

public class MethodInfoWrapper : InfoWrapper
{

    [JsonPropertyName("name")]
    [XmlAttribute("name")]
    [YamlMember(Alias = "name", Order = 1)]
    [JsonPropertyOrder(1)]
    public String Name
    {
        get;
        set;
    }

    public MethodInfoWrapper()
    {
    }

    [JsonPropertyName("class")]
    [XmlAttribute("class")]
    [YamlMember(Alias = "class", Order = 2)]
    [JsonPropertyOrder(2)]
    public String ClassName
    {
        get;
        set;
    }

    public MethodInfoWrapper(List<MethodInfo> methods, string time, string name, string className) : base(methods, time)
    {
        Name = name;
        ClassName = className;
    }
}