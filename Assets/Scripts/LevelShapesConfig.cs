using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/LevelConfig")]
public class LevelShapesConfig : ScriptableObject
{
    [SerializeField] private int _threesomeCount;
    [SerializeField] private List<ShapeConfig> _shapes;
    
    public int ThreesomeCount => _threesomeCount;
    public List<ShapeConfig> Shapes => new (_shapes);
}