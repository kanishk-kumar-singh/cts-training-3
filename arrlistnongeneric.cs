using System;
using System.Collections;

public class Program
{
    public static void Main()
    {
        ArrayList list = new ArrayList();
        list.Add(10);
        list.Add("Hello");
        list.Add(3.14);

        foreach (var item in list)
            Console.WriteLine(item);
    }
}
