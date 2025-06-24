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
    
    private bool _isInitialized;

    public void Init(ActionBarController controller)
    {
        if (_isInitialized) 
            return;
        
        _slots.Clear();
        
        foreach (var image in _slotImages)
        {
            _slots.Add(new ActionBarSlot(image, _slotDefaultImage));
        }
        
        _actionBarController = controller;
        _actionBarController.OnMatchFound += RemoveShapes;
        _actionBarController.OnShapeRemoved += RemoveShape;
        
        _isInitialized = true;
    }
    
    private void OnDisable()
    {
        _actionBarController.OnMatchFound -= RemoveShapes;
        _actionBarController.OnShapeRemoved -= RemoveShape;
    }

    public void AddShape(Shape shape)
    {
        foreach (var slot in _slots)
        {
            if (slot.IsOccupied) 
                continue;
            
            slot.SetShape(shape);
            return;
        }
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
        foreach (var slot in _slots)
        {
            if (slot.GetShape() != shape) 
                continue;
            
            slot.Clear();
            Destroy(shape.View);
        }
    }
}