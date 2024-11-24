using UnityEngine;
using Zenject;


public class BulletManager : MonoBehaviour
{
    private LevelBounds _levelBounds;
    private Bullet.BulletPool _bulletPool;
    
    [Inject]
    private void Construct(LevelBounds levelBounds, Bullet.BulletPool bulletPool)
    {
        _levelBounds = levelBounds;
        _bulletPool = bulletPool;
    }
    
    private void Start()
    {
        GameStateManager.Instance.GameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.GameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.PAUSE)
        {
            StopBullets();
        }
    }

    private void Update()
    {
        CheckingExitBulletsBeyondLevel();
    }

    private void CheckingExitBulletsBeyondLevel()
    {
        foreach (var bullet in _bulletPool.ActiveBullets)
        {
            if (!_levelBounds.InBounds(bullet.transform.position))
            {
                bullet.transform.position = _levelBounds.NewPosition(bullet.transform.position);
            }
        }
    }

    public void SpawnBullet(Vector3 position, Vector2 velocity)
    {
        Bullet bullet = _bulletPool.Spawn(position, velocity);
        bullet.BulletOff += RemoveBullet;
    }

    private void RemoveBullet(Bullet bullet)
    {
        bullet.BulletOff -= RemoveBullet;
        _bulletPool.Despawn(bullet);
    }

    private void StopBullets()
    {
        foreach (var bullet in _bulletPool.ActiveBullets)
        {
            bullet.Stop();
        }
    }
}