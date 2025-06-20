using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelShapesConfig _levelShapesConfig;
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private GameObject _shapesParent;
    private List<Shape> _shapes;
    
    private IShapesGenerator _shapesGenerator;

    private void Start()
    {
        _shapesGenerator = new PrefabShapesGenerator(_levelShapesConfig, _shapesParent.gameObject);
        _shapes = _shapesGenerator.GenerateShapes(_levelShapesConfig.ThreesomeCount);
        _objectSpawner.StartSpawn(GetObjectsToSpawn());
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
}