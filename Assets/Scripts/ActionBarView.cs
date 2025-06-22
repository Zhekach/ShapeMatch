using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarView : MonoBehaviour
{
    [SerializeField] private GameObject[] _slots =  new GameObject[7];
    private ActionBarController _controller;

    public void Init(ActionBarController controller)
    {
        _controller = controller;
        _controller.OnMatchFound += HandleMatchFound;
        _controller.OnLose += ShowLoseScreen;
    }

    public void AddShape(Shape shape)
    {
        var image = _slots[0].GetComponent<Image>();
        image.sprite = shape.Sprite;
        
        UpdateLayout(); // если надо расставлять визуально
    }

    private void HandleMatchFound(List<Shape> matchedShapes)
    {
        foreach (var shape in matchedShapes)
        {
            Destroy(shape.View); // или ObjectPool
        }

        UpdateLayout();
    }

    private void ShowLoseScreen()
    {
        Debug.Log("YOU LOSE!");
        // TODO: показать экран поражения
    }

    private void UpdateLayout()
    {
        // При необходимости перераспределить позиции
    }
}