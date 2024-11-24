using UnityEngine;
using Zenject;

public class GameContextInstaller : MonoInstaller
{   
    [SerializeField] private UFOManager ufoManager;
    [SerializeField] private BulletManager _bulletManager;
    [SerializeField] private ScoreConfig _scoreConfig;
    
    public override void InstallBindings()
    {
        BindGameOverController();
        BindPlayerInput();
        BindPlayerController();
        BindLevelBounds();
        
        BindEnemyManager();
        BindBulletManager();

        BindScore();
        BindScoreConfig();
    }

    private void BindGameOverController()
    {
        Container.BindInterfacesAndSelfTo<GameStateController>().AsSingle();
    }
    
    private void BindPlayerInput()
    {
        Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
    }
    
    private void BindPlayerController()
    {
        Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
    }
    
    private void BindLevelBounds()
    {
        Container.BindInterfacesAndSelfTo<LevelBounds>().AsSingle();
    }
    
    private void BindEnemyManager()
    {
        Container.Bind<UFOManager>().FromInstance(ufoManager).AsSingle();
    }
    
    private void BindBulletManager()
    {
        Container.BindInterfacesAndSelfTo<BulletManager>().FromInstance(_bulletManager).AsSingle();
    }
    
    private void BindScore()
    {
        Container.BindInterfacesAndSelfTo<Score>().AsSingle();
    }
    
    private void BindScoreConfig()
    {
        Container.BindInterfacesAndSelfTo<ScoreConfig>().FromInstance(_scoreConfig).AsSingle();
    }
}
