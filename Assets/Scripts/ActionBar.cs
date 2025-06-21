using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways] // позволяет обновлять в редакторе без Play Mode
public class ActionBar : MonoBehaviour
{
    private const int DesiredCount = 7;

    [Header("Настройки слотов")]
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private float _spacing = 1.5f;

    [Header("Слоты (автозаполняются)")]
    [SerializeField] private List<GameObject> _slots = new List<GameObject>(DesiredCount);

    private void OnValidate()
    {
        //RegenerateSlots();
        ControlSlotsCount();
    }

    private void RegenerateSlots()
    {
        // Удаление всех детей-слотов
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            if (Application.isPlaying)
                Destroy(child.gameObject);
            else
                DestroyImmediate(child.gameObject);
        }
        
        UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
        UnityEditor.SceneView.RepaintAll();
        
        _slots.Clear();

        // Создание новых слотов
        for (int i = 0; i < DesiredCount; i++)
        {
            float xOffset = i * _spacing;
            Vector3 position = transform.position + new Vector3(xOffset, 0, 0);
            GameObject slot = Instantiate(_slotPrefab, position, Quaternion.identity, transform);
            slot.name = $"Slot_{i}";
            _slots.Add(slot);
        }
    }

    private void ControlSlotsCount()
    {
        if (_slots.Count == 7) return;
        
        Debug.LogWarning("Массив должен содержать ровно 7 элементов. Исправляем.");
            
        while (_slots.Count < DesiredCount)
        {
            _slots.Add(null);
        }

        while (_slots.Count > DesiredCount)
        {
            _slots.RemoveAt(_slots.Count - 1);
        }
    }
}