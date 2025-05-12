using System;

public sealed class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    private Singleton() { }  // Private constructor prevents direct instantiation

    public static Singleton Instance
    {
        get
        {
            lock (_lock) // Ensures thread safety
            {
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }
    }

    public void ShowMessage() => Console.WriteLine("Singleton Instance is Working!");
}

public class Program
{
    public static void Main()
    {
        Singleton obj1 = Singleton.Instance;
        Singleton obj2 = Singleton.Instance;

        obj1.ShowMessage(); // Output: Singleton Instance is Working!

        Console.WriteLine(obj1 == obj2); // Output: True (Both references point to the same instance)
    }
}
