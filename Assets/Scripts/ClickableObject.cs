using System;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Shape _shape;
    private Action<Shape> _onClick;

    public void Init(Shape shape, Action<Shape> onClick)
    {
        _shape = shape;
        _onClick = onClick;
    }
    public void OnClicked()
    {
        _onClick?.Invoke(_shape);
        Debug.Log("Нажата фигурка: " + name);
    }
}