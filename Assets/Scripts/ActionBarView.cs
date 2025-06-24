using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarView : MonoBehaviour
{
    [SerializeField] private List<Image> _slotImages;
    [SerializeField] private Image _slotDefaultImage;
    
    private ActionBarController _actionBarController;
    private List <ActionBarSlot> _slots = new();

    public void Init(ActionBarController controller)
    {
        _slots.Clear();
        
        foreach (var image in _slotImages)
        {
            _slots.Add(new ActionBarSlot(image, _slotDefaultImage));
        }
        
        _actionBarController = controller;
        _actionBarController.OnMatchFound += RemoveShapes;
        _actionBarController.OnShapeRemoved += RemoveShape;
    }
    
    private void OnDisable()
    {
        _actionBarController.OnMatchFound -= RemoveShapes;
        _actionBarController.OnShapeRemoved -= RemoveShape;
    }

    public void AddShape(Shape shape)
    {
        var slot = _slots.FirstOrDefault(s => !s.IsOccupied);
        slot?.SetShape(shape);
    }

    private void RemoveShapes(List<Shape> matchedShapes)
    {
        foreach (var shape in matchedShapes)
        {
            RemoveShape(shape);
        }
    }
    
    private void RemoveShape(Shape shape)
    {
        var slot = _slots.FirstOrDefault(s => s.GetShape() == shape);
        
        if (slot == null) 
            return;
        
        slot.Clear();
        Destroy(shape.View);
    }
}