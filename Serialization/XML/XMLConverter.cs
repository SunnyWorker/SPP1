using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;
using System.Xml.Serialization;
using Core;
using Core.interfaces;
using Wrappers;

namespace XML;

public class XMLConverter : TraceResultSerializer
{
    public void Serialize(TraceResult traceResult, Stream to)
    {
        TraceResultWrapper traceResultWrapper = new TraceResultWrapper();
        traceResultWrapper = traceResultWrapper.ConvertTraceResultToTraceResultWrapper(traceResult);
        var settings = new XmlWriterSettings
        {
            Indent = true,
            Encoding = Encoding.UTF8
        };
        XmlWriter xmlWriter = XmlWriter.Create(to,settings);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceResultWrapper));
        xmlSerializer.Serialize(xmlWriter,traceResultWrapper);
    }
}