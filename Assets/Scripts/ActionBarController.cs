using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionBarController
{
    private readonly int _maxCapacity = 7;
    private readonly List<Shape> _shapes = new();
    private readonly int Threesome = 3;

    public event Action<List<Shape>> OnMatchFound;
    public event Action<Shape> OnShapeRemoved;
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
        List<List<Shape>> matchedGroups = FindMatchingTriples();

        foreach (var group in matchedGroups)
        {
            ApplyAbilities(group);
            RemoveShapes(group);
            OnMatchFound?.Invoke(group);
        }
    }
    
    private List<List<Shape>> FindMatchingTriples()
    {
        var result = new List<List<Shape>>();
        var counted = new HashSet<Shape>(); // чтобы не использовать одну фигурку дважды

        for (int i = 0; i < _shapes.Count; i++)
        {
            var s1 = _shapes[i];
            if (counted.Contains(s1)) continue;

            var group = new List<Shape> { s1 };

            for (int j = i + 1; j < _shapes.Count; j++)
            {
                var s2 = _shapes[j];
                if (counted.Contains(s2)) continue;

                if (IsSameType(s1, s2))
                {
                    group.Add(s2);
                    if (group.Count == Threesome)
                        break;
                }
            }

            if (group.Count == Threesome)
            {
                result.Add(group);
                foreach (var s in group)
                    counted.Add(s);
            }
        }

        return result;
    }

    private bool IsSameType(Shape a, Shape b)
    {
        return a.AnimalType == b.AnimalType &&
               a.FrameColor == b.FrameColor &&
               a.Figure == b.Figure;
    }

    private void RemoveShapes(List<Shape> shapesToRemove)
    {
        foreach (var shape in shapesToRemove)
        {
            _shapes.Remove(shape);
        }
    }
    
    private void ApplyAbilities(List<Shape> matched)
    {
        foreach (var shape in matched)
        {
            if (shape.Ability != AbilityType.Explosive) 
                continue;
            
            int index = _shapes.IndexOf(shape); // может уже не существовать
            if (index < 0)
                continue;

            List<Shape> neighbors = new();

            if (index > 0)
                neighbors.Add(_shapes[index - 1]);

            if (index < _shapes.Count - 1)
                neighbors.Add(_shapes[index + 1]);

            foreach (var neighbor in neighbors)
            {
                if (IsSameType(neighbor, shape))
                    continue;
                
                _shapes.Remove(neighbor);
                OnShapeRemoved?.Invoke(neighbor);
            }

        }
    }


    public IReadOnlyList<Shape> GetCurrentShapes() => _shapes;

    public void ResetShapes()
    {
        _shapes.Clear();
    }
}
