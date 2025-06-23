using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
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
        _restartButton.onClick.AddListener(_levelController.RestartGame);
    }
    
    private void OnDisable()
    {
        _levelController.OnLoseGame -= OnLoseGame;
        _levelController.OnWinGame -= OnWinGame;
        _restartButton.onClick.RemoveListener(_levelController.RestartGame);
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
