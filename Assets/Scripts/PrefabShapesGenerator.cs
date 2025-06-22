using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PrefabShapesGenerator : IShapesGenerator
{
    private LevelShapesConfig _shapesConfig;
    private event Action<Shape> _onShapeClicked;
    private readonly GameObject _parent;
    private const int Threesome = 3;
    private Random _random = new ();

    public PrefabShapesGenerator(LevelShapesConfig shapesConfig, GameObject parent, Action<Shape> onShapeClicked)
    {
        _shapesConfig = shapesConfig;
        _parent = parent;
        _onShapeClicked = onShapeClicked;
    }

    public List<Shape> GenerateShapes(int threesomesCount)
    {
        List<Shape> shapes = new List<Shape>();
        
        for (int i = 0; i < threesomesCount; i++)
        {
            shapes.AddRange(GenerateShapeThreesome());
        }
        
        ShuffleShapes(shapes);
        
        return shapes;
    }

    private List<Shape> GenerateShapeThreesome()
    {
        int randomShapeIndex = _random.Next(_shapesConfig.ShapeConfigs.Count);
        ShapeConfig shapeConfig = _shapesConfig.ShapeConfigs[randomShapeIndex];
        List<Shape> shapes = new List<Shape>();
        
        for (int i = 0; i < Threesome; i++)
        {
            Shape shape = new Shape(shapeConfig, _parent, _onShapeClicked);
            shapes.Add(shape);
        }

        return shapes;
    }

    private void ShuffleShapes(List<Shape> shapes)
    {
        for (int i = 0; i < shapes.Count; i++)
        {
            int j = _random.Next(i, shapes.Count); 
            (shapes[i], shapes[j]) = (shapes[j], shapes[i]);
        }
    }
}

public interface IShapesGenerator
{
    List<Shape> GenerateShapes(int threesomesCount);
}