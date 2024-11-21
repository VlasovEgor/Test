using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _newGameButton;

    private GameOverPresenter _gameOverPresenter;
    
    [Inject]
    private void Construct(GameOverPresenter gameOverPresenter)
    {
        _gameOverPresenter = gameOverPresenter;
    }
    
    private void Start()
    {
        _newGameButton.onClick.AddListener(() => _gameOverPresenter.OnNewGameButtonClicked());
    }

    private void OnDestroy()
    {
        _newGameButton.onClick.RemoveListener(() => _gameOverPresenter.OnNewGameButtonClicked());
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = $"Финальный счёт: {score}";
    }
    
}
