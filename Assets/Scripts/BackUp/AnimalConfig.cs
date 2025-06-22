using UnityEngine;

[CreateAssetMenu(fileName = "AnimalConfig", menuName = "Game/AnimalConfig")]
public class AnimalConfig : ScriptableObject
{
    [SerializeField] private AnimalType _animalType;
    [SerializeField] private Sprite _icon;

    public AnimalType AnimalType => _animalType;
    public Sprite Icon => _icon;
}
