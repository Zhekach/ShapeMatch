using UnityEngine;

public class Shape
{
    public AnimalType AnimalType { get; }
    public ColorType FrameColor { get; }
    public FigureType Figure { get; }
    public GameObject View { get; }

    public Shape(ShapeConfig config, GameObject parent)
    {
        AnimalType = config.AnimalType;
        FrameColor = config.ColorType;
        Figure = config.Figure;
        View = config.Prefab;


        Initialize(parent);
    }

    private void Initialize(GameObject parent)
    {
        View.transform.parent = parent.transform;
        View.SetActive(false);
    }
}