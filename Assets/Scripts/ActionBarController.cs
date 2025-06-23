using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionBarController
{
    private readonly int _maxCapacity = 7;
    private readonly List<Shape> _shapes = new();

    public event Action<List<Shape>> OnMatchFound;
    public event Action OnLose;

    public void AddShape(Shape shape)
    {
        _shapes.Add(shape);

        TryMatch();
        
        if (_shapes.Count == _maxCapacity)
        {
            OnLose?.Invoke();
            Debug.Log("YOU LOSE!");
        }
    }

    private void TryMatch()
    {
        // Поиск тройки по совпадению всех 3 параметров
        var groups = _shapes
            .GroupBy(s => new { s.AnimalType, s.FrameColor, s.Figure })
            .Where(g => g.Count() >= 3)
            .ToList();

        foreach (var group in groups)
        {
            var matched = group.Take(3).ToList(); // Только 3 штуки
            foreach (var s in matched)
                _shapes.Remove(s);

            OnMatchFound?.Invoke(matched);
        }
    }

    public IReadOnlyList<Shape> GetCurrentShapes() => _shapes;

    public void ResetShapes()
    {
        throw new NotImplementedException();
    }
}
