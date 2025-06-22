using UnityEngine;

public class InputClickDetector : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 inputPosition;

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            inputPosition = Input.mousePosition;
            CheckClick(inputPosition);
        }
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            inputPosition = Input.GetTouch(0).position;
            CheckClick(inputPosition);
        }
#endif
    }

    private void CheckClick(Vector2 screenPosition)
    {
        Vector2 worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null)
        {
            var clickable = hit.collider.GetComponent<ClickableObject>();
            if (clickable == null) return;
            clickable.OnClicked();
        }
    }
}