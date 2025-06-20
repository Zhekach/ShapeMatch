﻿using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ShapeConfig", menuName = "Game/ShapeConfig")]
public class ShapeConfig : ScriptableObject
{
    [SerializeField] private AnimalType _animalType;
    [SerializeField] private ColorType _colorType;
    [SerializeField] private FigureType _figure;
    
    [SerializeField] private GameObject _prefab;

    public AnimalType AnimalType => _animalType;
    public ColorType ColorType => _colorType;
    public FigureType Figure => _figure;
    public GameObject Prefab => Instantiate(_prefab);
}

public enum ColorType
{
    Red,
    Green,
    Blue,
    Yellow
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