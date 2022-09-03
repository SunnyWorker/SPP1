using System.Collections;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;

namespace Lab1;

public class TraceResult
{
    private string? name;
    private String className;
    private int time;
    private List<MethodBase> _arrayList;

    public string? Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string ClassName
    {
        get => className;
        set => className = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Time
    {
        get => time;
        set => time = value;
    }

    public List<MethodBase> ArrayList
    {
        get => _arrayList;
        set => _arrayList = value ?? throw new ArgumentNullException(nameof(value));
    }
}