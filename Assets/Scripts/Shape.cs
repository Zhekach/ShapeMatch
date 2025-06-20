using UnityEngine;

public class Shape
{
    private AnimalType _animalType;
    private ColorType _frameColor;
    private FigureType _figure;
    
    private GameObject _view;

    public Shape(ShapeConfig config)
    {
        _animalType = config.AnimalType;
        _frameColor = config.ColorType;
        _figure = config.Figure;
        _view = config.Prefab;
    }
}