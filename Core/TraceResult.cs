using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core.implementations;
using Core.interfaces;
using YamlDotNet.Serialization;

namespace Core;

[XmlInclude(typeof(ThreadInfo)), XmlInclude(typeof(MethodInfo))]
[XmlRoot(ElementName = "root", Namespace = null)]
public class TraceResult
{
    [JsonPropertyName("threads")]
    [XmlElement("thread")]
    [YamlMember(Alias = "threads")]
    public IReadOnlyList<ThreadInfo> Threads
    {
        get;
        set;
    }
    
    public TraceResult(List<ThreadInfo> methodsList)
    {
        Threads = methodsList;
    }

}