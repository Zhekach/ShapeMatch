using UnityEngine;

[CreateAssetMenu(fileName = "FigureConfig", menuName = "Game/FigureConfig")]
public class FigureConfig : ScriptableObject
{
    [SerializeField] private FigureType _type;
    [SerializeField] private Sprite _icon;
    
    public Sprite Icon => _icon;
    public FigureType Type => _type;
}
