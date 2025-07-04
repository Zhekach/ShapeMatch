﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelShapesConfig _levelShapesConfig;
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private GameObject _shapesParent;
    [SerializeField] private ActionBarView _actionBarView;
    [SerializeField] private InputClickDetector _inputClickDetector;

    private ActionBarController _actionBarController;
    private IShapesGenerator _shapesGenerator;
    private List<Shape> _shapes;

    public event Action OnLoseGame;
    public event Action OnWinGame;

    private void Awake()
    {
        _shapesGenerator = new PrefabShapesGenerator(_levelShapesConfig, _shapesParent.gameObject, OnShapeClicked);
        _actionBarController = new ActionBarController();
        _actionBarView.Init(_actionBarController);

        StartGame();
    }

    private void OnEnable()
    {
        _actionBarController.OnLose += LoseGame;
    }

    private void OnDisable()
    {
        _actionBarController.OnLose -= LoseGame;
    }


    public void RestartGame()
    {
        foreach (var shape in _shapes)
        {
            Destroy(shape.View);
        }

        _shapes = _shapesGenerator.GenerateShapes(_shapes.Count);
        _objectSpawner.StartSpawn(GetObjectsToSpawn());
    }

    private void StartGame()
    {
        int shapesCount = _levelShapesConfig.ThreesomeCount * _shapesGenerator.Threesome;
        _shapes = _shapesGenerator.GenerateShapes(shapesCount);
        _inputClickDetector.SetGameActivity(true);
        _objectSpawner.StartSpawn(GetObjectsToSpawn());   
    }

    private void LoseGame()
    {
        _inputClickDetector.SetGameActivity(false);
        OnLoseGame?.Invoke();
    }

    private List<GameObject> GetObjectsToSpawn()
    {
        var objectsToSpawn = new List<GameObject>();
        foreach (var shape in _shapes)
        {
            objectsToSpawn.Add(shape.View);
        }

        return objectsToSpawn;
    }

    private void OnShapeClicked(Shape shape)
    {
        _actionBarView.AddShape(shape);
        _actionBarController.AddShape(shape);
        Destroy(shape.View);
        _shapes.Remove(shape);

        if (_shapes.Count == 0)
            OnWinGame?.Invoke();
    }
}