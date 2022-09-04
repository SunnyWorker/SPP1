using System.Text;
using Lab1.interfaces;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YAML;

public class YAMLConverter : TraceResultSerializer
{
    public void Serialize(TraceResult traceResult, Stream to)
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        TextWriter textWriter = new StreamWriter(to);
        serializer.Serialize(textWriter,traceResult);
        textWriter.Flush();
        textWriter.Close();
    }
}