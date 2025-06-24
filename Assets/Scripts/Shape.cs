using System;
using UnityEngine;

public class Shape
{
    public AnimalType AnimalType { get; }
    public ColorType FrameColor { get; }
    public FigureType Figure { get; }
    public AbilityType Ability { get;}
    public GameObject View { get; }
    public Sprite  Sprite { get; }
    
    private readonly float _heavyGravityScale = 5f;

    public Shape(ShapeConfig config, GameObject parent, Action<Shape> onShapeClicked)
    {
        AnimalType = config.AnimalType;
        FrameColor = config.ColorType;
        Figure = config.Figure;
        Ability = config.Ability;
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
        
        ReleaseHeavyAbility();
    }

    private void ReleaseHeavyAbility()
    {
        if(Ability != AbilityType.Heavy)
            return;
        
        var rigidBody = View.GetComponent<Rigidbody2D>(); 
        rigidBody.gravityScale = _heavyGravityScale;
    }
}