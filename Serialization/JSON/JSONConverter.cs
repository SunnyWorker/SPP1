using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Lab1.interfaces;

namespace JSON;

public class JSONConverter : TraceResultSerializer
{
    public void Serialize(TraceResult traceResult, Stream to)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            
        };
        JsonSerializer.Serialize<object>(to,traceResult,options);
    }
}