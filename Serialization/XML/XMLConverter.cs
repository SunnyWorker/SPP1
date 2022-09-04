using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;
using System.Xml.Serialization;
using Lab1.interfaces;

namespace XML;

public class XMLConverter : TraceResultSerializer
{
    public void Serialize(TraceResult traceResult, Stream to)
    {
        var settings = new XmlWriterSettings
        {
            Indent = true,
            Encoding = Encoding.UTF8
        };
        XmlWriter xmlWriter = XmlWriter.Create(to,settings);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceResult));
        xmlSerializer.Serialize(xmlWriter,traceResult);
    }
}