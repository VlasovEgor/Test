using System;
using Zenject;

public class GameOverPresenter: IInitializable, IDisposable
{
    private GameStateController _gameStateController;
    private GameOverView _gameOverView;
    
    [Inject]
    private void Construct(GameStateController gameStateController, GameOverView gameOverView)
    {
        _gameStateController = gameStateController;
        _gameOverView = gameOverView;
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
    }

    public void OnNewGameButtonClicked()
    {   
        _gameOverView.Hide();
        _gameStateController.RestartGame();
    }
}
