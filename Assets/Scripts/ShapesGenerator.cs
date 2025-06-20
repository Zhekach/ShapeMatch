using System.Collections.Generic;

public class DefaultShapesGenerator : IShapesGenerator
{
    private readonly List<ShapeConfig> _shapes;
    private readonly List<AnimalConfig> _animalTypes;
    private readonly List<FigureConfig> _figureTypes;

    private const int Threesome = 3;

    public DefaultShapesGenerator(List<ShapeConfig> shapes, List<AnimalConfig> animalTypes, List<FigureConfig> figureTypes)
    {
        _shapes = shapes;
        _animalTypes = animalTypes;
        _figureTypes = figureTypes;
    }

    public List<ShapeView> GenerateShapes(int threesomesCount)
    {
        var shapes = new List<ShapeView>();

        for (int i = 0; i < threesomesCount; i++)
        {
        }


        return shapes;
    }

    private ShapeView GenerateShape()
    {
        return new ShapeView();
    }
}

public interface IShapesGenerator
{
    List<ShapeView> GenerateShapes(int threesomesCount);
}