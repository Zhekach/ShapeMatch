using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShapeView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _icon;
    [SerializeField] private SpriteRenderer _background;

    public void Initialize(ShapeConfig data)
    {
        var spriteRendererIcon = _icon.gameObject.GetComponent<SpriteRenderer>();
        //spriteRendererIcon.sprite = data.Icon;
        
        var spriteRendererFrame = _background.gameObject.GetComponent<SpriteRenderer>();
        //spriteRendererFrame.color = data.FrameColor;
    }
}
