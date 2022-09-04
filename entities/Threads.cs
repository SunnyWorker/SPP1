using Lab1.implementations;

namespace Lab1.entities;

public class Threads
{
    public List<ThreadWrapper> threads
    {
        get;
        set;
    }

    public Threads()
    {
        threads = new List<ThreadWrapper>();
    }


}