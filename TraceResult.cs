using System.Collections;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Lab1;

public struct TraceResult
{
    private string? name;
    private String className;
    [field: NonSerialized]
    public int TimeInt;
    [JsonPropertyName("methods")]
    private List<TraceResult> _methods;

    [JsonPropertyName("name")]
    public string? Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    [JsonPropertyName("class")]
    public string ClassName
    {
        get => className;
        set => className = value ?? throw new ArgumentNullException(nameof(value));
    }

    [JsonPropertyName("time")]
    public string Time
    {
        get => String.Format("{0}ms",TimeInt);
    }

    [JsonPropertyName("methods")]
    public List<TraceResult> Methods
    {
        get => _methods;
        set => _methods = value ?? throw new ArgumentNullException(nameof(value));
    }
}