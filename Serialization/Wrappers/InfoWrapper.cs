using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core;
using YamlDotNet.Serialization;

namespace Wrappers;

public class InfoWrapper
{
    [JsonPropertyName("methods")]
    [XmlElement("method")]
    [YamlMember(Alias = "methods", Order = 4)]
    [JsonPropertyOrder(4)]
    public List<MethodInfoWrapper> Methods
    {
        get;
        set;
    }

    public InfoWrapper()
    {
    }

    [JsonPropertyName("time")]
    [XmlAttribute("time")]
    [YamlMember(Alias = "time", Order = 3)]
    [JsonPropertyOrder(3)]
    public virtual String Time { get; set; }

    public InfoWrapper(List<MethodInfo> methods, string time)
    {
        List<MethodInfoWrapper> methodInfoWrappers = new List<MethodInfoWrapper>();
        foreach (var methodInfo in methods)
        {
            MethodInfoWrapper methodInfoWrapper = new MethodInfoWrapper(
                methodInfo.Methods,
                methodInfo.Time,
                methodInfo.Name,
                methodInfo.ClassName);
            methodInfoWrappers.Add(methodInfoWrapper);
        }
        Methods = methodInfoWrappers;
        Time = time;
    }
}