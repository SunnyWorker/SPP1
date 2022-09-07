using Core;
using Core.interfaces;
using Wrappers;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YAML;

public class YAMLConverter : TraceResultSerializer
{
    public void Serialize(TraceResult traceResult, Stream to)
    {
        TraceResultWrapper traceResultWrapper = new TraceResultWrapper();
        traceResultWrapper = traceResultWrapper.ConvertTraceResultToTraceResultWrapper(traceResult);
        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        TextWriter textWriter = new StreamWriter(to);
        serializer.Serialize(textWriter,traceResultWrapper);
        textWriter.Flush();
        textWriter.Close();
    }
}