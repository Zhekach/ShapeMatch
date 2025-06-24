using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionBarController
{
    private const int MaxCapacity = 7;
    private const int MatchCount = 3;

    private readonly List<Shape> _shapes = new();

    public event Action<List<Shape>> OnMatchFound;
    public event Action<Shape> OnShapeRemoved;
    public event Action OnLose;

    public void AddShape(Shape shape)
    {
        _shapes.Add(shape);

        TryMatch();

        if (_shapes.Count >= MaxCapacity)
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
        var counted = new HashSet<Shape>();

        for (int i = 0; i < _shapes.Count; i++)
        {
            var s1 = _shapes[i];
            if (counted.Contains(s1)) continue;

            var group = new List<Shape> { s1 };

            for (int j = i + 1; j < _shapes.Count; j++)
            {
                var s2 = _shapes[j];
                if (counted.Contains(s2)) continue;

                if (s1.Equals(s2))
                {
                    group.Add(s2);
                    if (group.Count == MatchCount)
                        break;
                }
            }

            if (group.Count != MatchCount)
                continue;

            result.Add(group);
            foreach (var s in group)
                counted.Add(s);
        }

        return result;
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

            int index = _shapes.IndexOf(shape);
            if (index < 0)
                continue;

            var neighbors = new List<Shape>();

            if (index > 0)
                neighbors.Add(_shapes[index - 1]);
            if (index < _shapes.Count - 1)
                neighbors.Add(_shapes[index + 1]);

            var toRemove = new List<Shape>();
            foreach (var neighbor in neighbors)
            {
                if (neighbor.Equals(shape) == false)
                    toRemove.Add(neighbor);
            }

            foreach (var victim in toRemove)
            {
                _shapes.Remove(victim);
                OnShapeRemoved?.Invoke(victim);
            }
        }
    }
}