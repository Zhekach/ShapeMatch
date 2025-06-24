using System;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Shape _shape;
    private Action<Shape> _onClick;
    private bool _isInitialized;

    public void Init(Shape shape, Action<Shape> onClick)
    {
        _shape = shape ?? throw new ArgumentNullException(nameof(shape));
        _onClick = onClick ?? throw new ArgumentNullException(nameof(onClick));
        _isInitialized = true;
    }

    public void OnClicked()
    {
        if (!_isInitialized)
        {
            Debug.LogWarning($"{name}: Clicked before Init was called.");
            return;
        }

        _onClick?.Invoke(_shape);

#if UNITY_EDITOR
        Debug.Log("Нажата фигурка: " + name);
#endif
    }

    private void OnDestroy()
    {
        _shape = null;
        _onClick = null;
        _isInitialized = false;
    }
}