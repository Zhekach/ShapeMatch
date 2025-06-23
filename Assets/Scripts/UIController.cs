using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private LevelController _levelController;

    private void Start()
    {
        _losePanel.SetActive(false);
        _winPanel.SetActive(false);

    }
    
    private void OnEnable()
    {
        _levelController.OnLoseGame += OnLoseGame;
        _levelController.OnWinGame += OnWinGame;
    }
    
    private void OnDisable()
    {
        _levelController.OnLoseGame -= OnLoseGame;
        _levelController.OnWinGame -= OnWinGame;
    }

    private void OnLoseGame()
    {
        _losePanel.SetActive(true);
    }

    private void OnWinGame()
    {
        _winPanel.SetActive(true);
    }
}
