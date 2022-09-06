using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core.implementations;
using Core.interfaces;
using YamlDotNet.Serialization;

namespace Core;

[XmlInclude(typeof(TraceResultThread)), XmlInclude(typeof(TraceResultMethods))]
[XmlRoot(ElementName = "root", Namespace = null)]
public class Threads : TraceResult
{
    [JsonPropertyName("threads")]
    [XmlElement("thread")]
    [YamlMember(Alias = "threads")]
    public List<TraceResultThread> Methods
    {
        get;
        set;
    }
    
    


    public Threads()
    {
        Methods = new List<TraceResultThread>();
    }

    [field: NonSerialized]
    [XmlIgnore]
    [JsonIgnore]
    [YamlIgnore]
    public override string? Time { get;}


}