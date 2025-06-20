using UnityEngine;
using UnityEngine.UI;

public class ShapeView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _frame;

    public void Initialize(ShapeConfig data)
    {
        _icon.sprite = data.Icon;
        _frame.color = data.FrameColor;
        // форма – через спрайт или маску, если надо
    }
}
