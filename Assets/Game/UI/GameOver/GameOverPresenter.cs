using System;
using Zenject;

public class GameOverPresenter: IInitializable, IDisposable
{
    private GameStateController _gameStateController;
    private GameOverView _gameOverView;
    private Score _score;
    
    [Inject]
    private void Construct(GameStateController gameStateController, GameOverView gameOverView, Score score)
    {
        _gameStateController = gameStateController;
        _gameOverView = gameOverView;
        _score = score;
    }
    
    public void Initialize()
    {
        _gameStateController.GameStopped += OpenGameStateView;
    }

    public void Dispose()
    {
        _gameStateController.GameStopped -= OpenGameStateView;
    }

    private void OpenGameStateView()
    {
        _gameOverView.Show();
        _gameOverView.UpdateScore(_score.GetScore());
    }

    public void OnNewGameButtonClicked()
    {   
        _gameOverView.Hide();
        _gameStateController.RestartGame();
    }
}
