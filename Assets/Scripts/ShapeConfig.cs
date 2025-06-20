using UnityEngine;

[CreateAssetMenu(fileName = "ShapeConfig", menuName = "Game/ShapeConfig")]
public class ShapeConfig : ScriptableObject
{
    [SerializeField] private AnimalType AnimalType;
    [SerializeField] private Color FrameColor;
    [SerializeField] private FigureType Figure;
}

public enum FigureType
{
    Circle,
    Square,
    Triangle,
}

public enum AnimalType
{
    Dolphin,
    Hamster,
    Owl,
    Cat,
    Dog,
}