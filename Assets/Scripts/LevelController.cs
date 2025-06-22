using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelShapesConfig _levelShapesConfig;
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private GameObject _shapesParent;
    [SerializeField] private ActionBarView _actionBarView;
    
    private ActionBarController _actionBarController;
    private IShapesGenerator _shapesGenerator;
    private List<Shape> _shapes;
    
    private void Start()
    {
        _shapesGenerator = new PrefabShapesGenerator(_levelShapesConfig, _shapesParent.gameObject, OnShapeClicked);
        _shapes = _shapesGenerator.GenerateShapes(_levelShapesConfig.ThreesomeCount);
        _objectSpawner.StartSpawn(GetObjectsToSpawn());
        
        _actionBarController = new ActionBarController();
        _actionBarView.Init(_actionBarController);
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
        shape.View.SetActive(false);
    }
}