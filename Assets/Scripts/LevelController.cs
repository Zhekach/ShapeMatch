using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelShapesConfig _levelShapesConfig;
    [SerializeField] private List<Shape> _shapes;
    
    private IShapesGenerator _shapesGenerator;

    private void Start()
    {
        _shapesGenerator = new PrefabShapesGenerator(_levelShapesConfig);
        _shapes = _shapesGenerator.GenerateShapes(_levelShapesConfig.ThreesomeCount);
    }
}