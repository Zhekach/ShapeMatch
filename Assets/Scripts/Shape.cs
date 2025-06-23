using System;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class Shape
{
    public AnimalType AnimalType { get; }
    public ColorType FrameColor { get; }
    public FigureType Figure { get; }
    public GameObject View { get; }
    public Sprite  Sprite { get; }

    public Shape(ShapeConfig config, GameObject parent, Action<Shape> onShapeClicked)
    {
        AnimalType = config.AnimalType;
        FrameColor = config.ColorType;
        Figure = config.Figure;
        View = config.Prefab;
        Sprite = config.Sprite;

        Initialize(parent, onShapeClicked);
    }

    private void Initialize(GameObject parent, Action<Shape> onShapeClicked)
    {
        View.AddComponent<ClickableObject>();
        //View.AddComponent<ShapePhysics>();
        View.transform.parent = parent.transform;
        View.name = AnimalType.ToString() + FrameColor.ToString() + Figure.ToString();
        View.GetComponent<ClickableObject>().Init(this, onShapeClicked);
        View.SetActive(false);
    }
}