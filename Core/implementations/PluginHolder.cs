using System.Reflection;
using Core.interfaces;

namespace Core.implementations;

public class PluginHolder
{
    public Dictionary<String, Assembly> AssemblyDictionary
    {
        get;
        set;
    }

    public PluginHolder()
    {
        FindPlugins();
    }

    private void FindPlugins()
    {
        AssemblyDictionary = new Dictionary<string, Assembly>();
        String path = "..\\..\\..\\..\\Serialization";
        foreach (var pluginDirectory in Directory.GetDirectories(path))
        {
            String fileName = Path.GetFileName(pluginDirectory);
            if(fileName.Equals(".idea") || fileName.Equals("Wrappers")) continue;
            AssemblyDictionary.Add(fileName,Assembly.LoadFrom($"{path}\\{fileName}\\bin\\Debug\\net6.0\\{fileName}.dll"));
        }
    }
    
    public TraceResultSerializer GetPlugin(String pluginName)
    {
        Type type = AssemblyDictionary[pluginName].GetType($"{pluginName}.{pluginName}Converter"); 
        TraceResultSerializer traceResultSerializer = (TraceResultSerializer)Activator.CreateInstance(type);
        return traceResultSerializer;
    }
}