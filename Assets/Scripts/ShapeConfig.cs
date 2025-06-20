using UnityEngine;

[CreateAssetMenu(fileName = "ShapeConfig", menuName = "Game/ShapeConfig")]
public class ShapeConfig : ScriptableObject
{
    public Sprite Icon;
    public Color FrameColor;
    public FigureType Figure;
}

public enum FigureType
{
    Circle,
    Square,
    Triangle,
}