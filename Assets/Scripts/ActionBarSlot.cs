using System;
using UnityEngine.UI;

public class ActionBarSlot
{
    private Shape _currentShape;
    
    private readonly Image _image;
    private readonly Image _defaultImage;
    
    public bool IsOccupied => _currentShape != null;

    public ActionBarSlot(Image image, Image defaultImage)
    {
        _image = image ?? throw new ArgumentNullException(nameof(image));
        _defaultImage = defaultImage ?? throw new ArgumentNullException(nameof(defaultImage));
        
        Clear();
    }

    public void SetShape(Shape shape)
    {
        _currentShape = shape ?? throw new ArgumentNullException(nameof(shape));
        _image.sprite = shape.Sprite;
    }

    public void Clear()
    {
        _currentShape = null;
        _image.sprite = _defaultImage.sprite;
    }

    public Shape GetShape() => _currentShape;
}