using System;
using UnityEngine;
using Zenject;

public class GameContextInstaller : MonoInstaller
{
    [SerializeField] private UFOManager ufoManager;
    [SerializeField] private BulletManager _bulletManager;
    [SerializeField] private ScoreConfig _scoreConfig;
    
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletParent;
    [SerializeField] private int _initialPoolSize = 10;

    public override void InstallBindings()
    {   
        BindBulletPool();
        
        BindGameOverController();
        BindPlayerInput();
        BindPlayerController();
        BindLevelBounds();

        BindEnemyManager();
        BindBulletManager();

        BindScore();
        BindScoreConfig();
    }

    private void BindBulletPool()
    {
        Container.BindMemoryPool<Bullet, Bullet.BulletPool>()
            .WithInitialSize(_initialPoolSize).
            WithMaxSize(100).
            ExpandByOneAtATime()
            .FromComponentInNewPrefab(_bulletPrefab)
            .UnderTransform(_bulletParent);
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