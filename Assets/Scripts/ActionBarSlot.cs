using UnityEngine.UI;

public class ActionBarSlot
{
    private Image Image { get; }
    private Shape _currentShape;
    private readonly Image _defaultImage;

    public bool IsOccupied => _currentShape != null;

    public ActionBarSlot(Image image, Image defaultImage)
    {
        _defaultImage  = defaultImage;
        Image = image;
        Clear();
    }

    public void SetShape(Shape shape)
    {
        _currentShape = shape;
        Image.sprite = shape.Sprite;
        Image.enabled = true;
    }

    public void Clear()
    {
        _currentShape = null;
        Image.sprite = _defaultImage.sprite;
    }

    public Shape GetShape() => _currentShape;
}