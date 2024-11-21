using System;
using Zenject;

public class GameOverPresenter: IInitializable, IDisposable
{
    private GameOverController _gameOverController;
    private GameOverView _gameOverView;
    
    [Inject]
    private void Construct(GameOverController gameOverController, GameOverView gameOverView)
    {
        _gameOverController = gameOverController;
        _gameOverView = gameOverView;
    }
    
    public void Initialize()
    {
        _gameOverController.GameOver += OpenGameOverView;
    }

    public void Dispose()
    {
        _gameOverController.GameOver -= OpenGameOverView;
    }

    private void OpenGameOverView()
    {
        _gameOverView.Show();
    }

    public void OnNewGameButtonClicked()
    {   
        _gameOverView.Hide();
    }
}
