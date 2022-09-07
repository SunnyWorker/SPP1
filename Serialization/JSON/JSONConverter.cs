using System.Text.Json;
using Core;
using Core.interfaces;
using Wrappers;

namespace JSON;

public class JSONConverter : TraceResultSerializer
{
    public void Serialize(TraceResult traceResult, Stream to)
    {
        TraceResultWrapper traceResultWrapper = new TraceResultWrapper();
        traceResultWrapper = traceResultWrapper.ConvertTraceResultToTraceResultWrapper(traceResult);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        JsonSerializer.Serialize<object>(to,traceResultWrapper,options);
    }
    
}