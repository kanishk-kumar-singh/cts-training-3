// Step 1: Define an interface for Shapes
public interface IShape
{
    void Draw();
}

// Step 2: Create Concrete Implementations (Circle and Square)
public class Circle : IShape
{
    public void Draw() => Console.WriteLine("Drawing a Circle!");
}

public class Square : IShape
{
    public void Draw() => Console.WriteLine("Drawing a Square!");
}

// Step 3: Factory Method to Create Shapes
public class ShapeFactory
{
    public static IShape GetShape(string shapeType)
    {
        return shapeType switch
        {
            "Circle" => new Circle(),
            "Square" => new Square(),
            _ => throw new ArgumentException("Invalid shape type")
        };
    }
}

// Step 4: Using the Factory Method
public class Program
{
    public static void Main()
    {
        IShape shape1 = ShapeFactory.GetShape("Circle");
        shape1.Draw(); // Output: Drawing a Circle!

        IShape shape2 = ShapeFactory.GetShape("Square");
        shape2.Draw(); // Output: Drawing a Square!
    }
}
