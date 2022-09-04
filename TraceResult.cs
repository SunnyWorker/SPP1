using System.Collections;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Lab1;

public struct TraceResult
{
    private string? name;
    private String className;
    private int time;
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
    public int Time
    {
        get => time;
        set => time = value;
    }

    [JsonPropertyName("methods")]
    public List<TraceResult> Methods
    {
        get => _methods;
        set => _methods = value ?? throw new ArgumentNullException(nameof(value));
    }
}