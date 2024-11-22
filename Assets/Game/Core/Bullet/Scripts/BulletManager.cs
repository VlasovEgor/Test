using UnityEngine;
using Zenject;


public class BulletManager : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _initialSizePool;

    private LevelBounds _levelBounds;

    private PoolObject<Bullet> _bulletPool;
    
    [Inject]
    private void Construct(LevelBounds levelBounds)
    {
        _levelBounds = levelBounds;
    }
    
    private void Start()
    {
        _bulletPool = new PoolObject<Bullet>(_prefab, transform, _initialSizePool);
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
        var activeBullet = _bulletPool.GetActiveObjects();

        for (int i = 0; i < activeBullet.Count; i++)
        {
            if (_levelBounds.InBounds(activeBullet[i].transform.position) == false)
            {
                activeBullet[i].transform.position = _levelBounds.NewPosition(activeBullet[i].transform.position);
            }
        }
    }

    public Bullet SpawnBullet(Vector2 position)
    {
        Bullet bullet = _bulletPool.GetObject();
        bullet.Activate();
        bullet.SetPosition(position);
        bullet.BulletOff += RemoveBullet;

        return bullet;
    }

    private void RemoveBullet(Bullet bullet)
    {
        bullet.BulletOff -= RemoveBullet;
        _bulletPool.ReturnObject(bullet);
    }

    private void StopBullets()
    {
        var activeBullet = _bulletPool.GetActiveObjects();

        foreach (var bullet in activeBullet)
        {
            bullet.Stop();
        }
    }
}