using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelShapesConfig _levelShapesConfig;
    [SerializeField] private List<AnimalConfig> _animalConfigs;
    [SerializeField] private List<FigureConfig> _figureConfigs;
    
    private IShapesGenerator _shapesGenerator;

    private void Start()
    {
        _shapesGenerator = new DefaultShapesGenerator(_levelShapesConfig.ShapeConfigs, _animalConfigs, _figureConfigs);
        _shapesGenerator.GenerateShapes(_levelShapesConfig.ThreesomeCount);
    }
}