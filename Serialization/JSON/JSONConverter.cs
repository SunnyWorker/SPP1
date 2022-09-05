using System.Text.Json;
using Core.interfaces;

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