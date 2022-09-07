using System.Collections;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core.interfaces;
using Microsoft.VisualBasic.CompilerServices;
using YamlDotNet.Serialization;

namespace Core;

public class MethodInfo : Info
{

    public MethodInfo()
    {
    }

    public MethodInfo(string? name, string className, List<MethodInfo> methods)
    {
        Name = name;
        ClassName = className;
        Methods = methods;
    }
    

    [JsonPropertyName("name")]
    [XmlAttribute("name")]
    [YamlMember(Alias = "name", Order = 1)]
    [JsonPropertyOrder(1)]
    public String Name
    {
        get;
        set;
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
    
}