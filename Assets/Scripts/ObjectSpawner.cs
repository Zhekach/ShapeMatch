using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Площадь спавна")]
    [SerializeField] private Transform _areaCenter; // позиция центра спавна
    [SerializeField] private Vector2 _areaSize = new Vector2(4f, 2f); // ширина/высота спавна

    [Header("Настройки")]
    [SerializeField] private float _spawnInterval = 0.5f;

    private List<GameObject> _objectsToSpawn;
    private List<GameObject> _spawnedObjects;

    public void StartSpawn(List<GameObject> objects)
    {
        _objectsToSpawn = objects;
        _spawnedObjects = new List<GameObject>();
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (_objectsToSpawn.Count > 0)
        {
            SpawnOne(_objectsToSpawn[0]);
            _spawnedObjects.Add(_objectsToSpawn[0]);
            _objectsToSpawn.RemoveAt(0);
            
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnOne(GameObject objectToSpawn)
    {
        Vector3 spawnPosition = GetRandomPointInArea();
        objectToSpawn.transform.position = spawnPosition;
        objectToSpawn.SetActive(true);
    }

    private Vector3 GetRandomPointInArea()
    {
        float halfX = _areaSize.x / 2f;
        float halfY = _areaSize.y / 2f;

        float x = UnityEngine.Random.Range(-halfX, halfX);
        float y = UnityEngine.Random.Range(-halfY, halfY);

        Vector3 offset = new Vector3(x, y, 0);
        return _areaCenter.position + offset;
    }

    private void OnDrawGizmosSelected()
    {
        if (_areaCenter == null) return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(_areaCenter.position, new Vector3(_areaSize.x, _areaSize.y, 0.1f));
    }
}