using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public void OnClicked()
    {
        Debug.Log("Нажата фигурка: " + name);
        // вызывай действия: анимация, перемещение в бар и т.п.
    }
}