namespace Core.interfaces;

public interface TraceResultSerializer
{
    void Serialize(TraceResult traceResult, Stream to);
}