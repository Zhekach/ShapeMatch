using System;
using System.Collections.Generic;

public class PrefabShapesGenerator : IShapesGenerator
{
    private LevelShapesConfig _shapesConfig;
    private const int Threesome = 3;
    private Random _random = new ();

    public PrefabShapesGenerator(LevelShapesConfig shapesConfig)
    {
        _shapesConfig = shapesConfig;
    }

    public List<Shape> GenerateShapes(int threesomesCount)
    {
        List<Shape> shapes = new List<Shape>();
        
        for (int i = 0; i < threesomesCount; i++)
        {
            shapes.AddRange(GenerateShapeThreesome());
        }
        
        return shapes;
    }

    private List<Shape> GenerateShapeThreesome()
    {
        int randomShapeIndex = _random.Next(_shapesConfig.ShapeConfigs.Count);
        ShapeConfig shapeConfig = _shapesConfig.ShapeConfigs[randomShapeIndex];
        
        List<Shape> shapes = new List<Shape>();
        for (int i = 0; i < Threesome; i++)
        {
            Shape shape = new Shape(shapeConfig);
            shapes.Add(shape);
        }

        return shapes;
    }
}

public interface IShapesGenerator
{
    List<Shape> GenerateShapes(int threesomesCount);
}