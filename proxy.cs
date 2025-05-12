using System;

public interface IFileAccess
{
    void OpenFile();
}

public class RealFileAccess : IFileAccess
{
    public void OpenFile() => Console.WriteLine("Opening the file...");
}

public class FileAccessProxy : IFileAccess
{
    private RealFileAccess _realFileAccess;
    private bool _isAuthenticated;

    public FileAccessProxy(bool isAuthenticated) => _isAuthenticated = isAuthenticated;

    public void OpenFile()
    {
        if (_isAuthenticated)
        {
            _realFileAccess ??= new RealFileAccess(); // Lazy initialization
            _realFileAccess.OpenFile();
        }
        else
        {
            Console.WriteLine("Access Denied! Please authenticate.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        IFileAccess user1 = new FileAccessProxy(true);  // Authenticated User
        user1.OpenFile();  // Output: Opening the file...

        IFileAccess user2 = new FileAccessProxy(false); // Unauthenticated User
        user2.OpenFile();  // Output: Access Denied! Please authenticate.
    }
}
