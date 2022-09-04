using System.Collections;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Lab1.interfaces;
using Microsoft.VisualBasic.CompilerServices;
using YamlDotNet.Serialization;

namespace Lab1;

public class TraceResultMethods : TraceResult
{
    private string? _name;
    private String _className;

    [JsonPropertyName("methods")]
    [XmlElement("method")]
    [YamlMember(Alias = "methods", Order = 4)]
    [JsonPropertyOrder(4)]
    public List<TraceResultMethods> Methods
    {
        get;
        set;
    }

    [JsonPropertyName("time")]
    [XmlAttribute("time")]
    [YamlMember(Alias = "time", Order = 3)]
    [JsonPropertyOrder(3)]
    public override string? Time { get => $"{TimeInt}ms"; }

    [JsonPropertyName("name")]
    [XmlAttribute("name")]
    [YamlMember(Alias = "name", Order = 1)]
    [JsonPropertyOrder(1)]
    public string? Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    [JsonPropertyName("class")]
    [XmlAttribute("class")]
    [YamlMember(Alias = "class", Order = 2)]
    [JsonPropertyOrder(2)]
    public string ClassName
    {
        get => _className;
        set => _className = value ?? throw new ArgumentNullException(nameof(value));
    }
    
}