using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Core;
using Core.implementations;
using YamlDotNet.Serialization;
using MethodInfo = System.Reflection.MethodInfo;

namespace Wrappers;

[XmlInclude(typeof(ThreadInfoWrapper)), XmlInclude(typeof(MethodInfoWrapper))]
[XmlRoot(ElementName = "root", Namespace = null)]
public class TraceResultWrapper
{
    
    [JsonPropertyName("threads")]
    [XmlElement("thread")]
    [YamlMember(Alias = "threads")]
    public List<ThreadInfoWrapper> Threads
    {
        get;
        set;
    }

    public TraceResultWrapper()
    {
    }

    private TraceResultWrapper(List<ThreadInfoWrapper> methodsList)
    {
        Threads = methodsList;
    }

    public TraceResultWrapper ConvertTraceResultToTraceResultWrapper(TraceResult traceResult)
    {
        List<ThreadInfoWrapper> threadInfoWrappers = new List<ThreadInfoWrapper>();
        foreach (var threadInfo in traceResult.Threads)
        {
            ThreadInfoWrapper threadInfoWrapper = new ThreadInfoWrapper(threadInfo.Id,
                threadInfo.Methods,
                threadInfo.Time);
            threadInfoWrappers.Add(threadInfoWrapper);
        }

        return new TraceResultWrapper(threadInfoWrappers);
    }
    
}