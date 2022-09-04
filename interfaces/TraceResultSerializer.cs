namespace Lab1.interfaces;

public interface TraceResultSerializer
{
    void Serialize(TraceResult traceResult, Stream to);
}