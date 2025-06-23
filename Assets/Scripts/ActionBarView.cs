using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarView : MonoBehaviour
{
    [SerializeField] private List<Image> _slotImages;
    [SerializeField] private Image _slotDefaultImage;
    
    private ActionBarController _actionBarController;
    private List<ActionBarSlot> _slots = new();

    public void Init(ActionBarController controller)
    {
        _slots.Clear();
        
        foreach (var image in _slotImages)
        {
            _slots.Add(new ActionBarSlot(image, _slotDefaultImage));
        }
        
        _actionBarController = controller;
        _actionBarController.OnMatchFound += RemoveShapes;
    }

    public void AddShape(Shape shape)
    {
        var slot = _slots.FirstOrDefault(s => !s.IsOccupied);
        if (slot != null)
            slot.SetShape(shape);
    }

    public void RemoveShapes(List<Shape> matchedShapes)
    {
        foreach (var shape in matchedShapes)
        {
            var slot = _slots.FirstOrDefault(s => s.GetShape() == shape);
            if (slot != null)
            {
                slot.Clear();
                Destroy(shape.View);
            }
        }
    }

    public void ResetShapes()
    {
        throw new System.NotImplementedException();
    }
}