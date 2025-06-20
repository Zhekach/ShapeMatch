using System.Collections.Generic;

public class DefaultShapesGenerator : IShapesGenerator
{
    private readonly List<ShapeConfig> _shapes;

    private const int Threesome = 3;

    public DefaultShapesGenerator(List<ShapeConfig> shapes)
    {
        _shapes = shapes;
    }
    
    public List<ShapeView> GenerateShapes(int threesomesCount)
    {
        var shapes = new List<ShapeView>();

        for (int i = 0; i < threesomesCount; i++)
        {
            
        }
        
        
        return shapes;
    }
}

public interface IShapesGenerator
{
    List<ShapeView> GenerateShapes(int threesomesCount);
}
