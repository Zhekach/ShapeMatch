using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PrefabShapesGenerator : IShapesGenerator
{
    private LevelShapesConfig _shapesConfig;

    private readonly GameObject _parent;
    private Random _random = new();

    private event Action<Shape> _onShapeClicked;

    public PrefabShapesGenerator(LevelShapesConfig shapesConfig, GameObject parent, Action<Shape> onShapeClicked)
    {
        _shapesConfig = shapesConfig;
        _parent = parent;
        _onShapeClicked = onShapeClicked;
    }

    public int Threesome { get; } = 3;

    public List<Shape> GenerateShapes(int totalCount)
    {
        if (_shapesConfig.ShapeConfigs.Count == 0)
            throw new InvalidOperationException("Нет доступных ShapeConfig для генерации.");

        List<Shape> result = new();

        int fullThreesomes = totalCount / Threesome;
        int remainder = totalCount % Threesome;

        // 1. Полные тройки
        for (int i = 0; i < fullThreesomes; i++)
        {
            result.AddRange(GenerateShapeThreesome());
        }

        // 2. Остаток — одиночные фигуры
        var randomConfig = GetRandomConfig();
        for (int i = 0; i < remainder; i++)
        {
            result.Add(GenerateSingleShape(randomConfig));
        }

        ShuffleShapes(result);
        return result;
    }

    private List<Shape> GenerateShapeThreesome()
    {
        var config = GetRandomConfig();
        var shapes = new List<Shape>();

        for (int i = 0; i < Threesome; i++)
        {
            var shape = new Shape(config, _parent, _onShapeClicked);
            shapes.Add(shape);
        }

        return shapes;
    }

    private Shape GenerateSingleShape(ShapeConfig config)
    {
        var result = new Shape(config, _parent, _onShapeClicked);
        return result;
    }

    private ShapeConfig GetRandomConfig()
    {
        int index = _random.Next(_shapesConfig.ShapeConfigs.Count);
        return _shapesConfig.ShapeConfigs[index];
    }

    private void ShuffleShapes(List<Shape> shapes)
    {
        for (int i = shapes.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (shapes[i], shapes[j]) = (shapes[j], shapes[i]);
        }
    }
}

public interface IShapesGenerator
{
    int Threesome { get; }
    List<Shape> GenerateShapes(int threesomesCount);
}