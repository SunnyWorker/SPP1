namespace Lab1.entities;

public class Threads
{
    private List<Thread> _threads;

    public List<Thread> Threads1
    {
        get => _threads;
        set => _threads = value ?? throw new ArgumentNullException(nameof(value));
    }
}