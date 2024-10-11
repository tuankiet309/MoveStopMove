using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    

    private ObjectPool<Enemy> enemyPool;

    public static EnemyPool Instance;

    private void Awake()
    {
        enemyPool = new ObjectPool<Enemy>(CreateEnemy, OnGetEnemy, OnReleaseEnemy, OnDestroyEnemy, false, CONSTANT_VALUE.LEAST_ENEMY_POOL, CONSTANT_VALUE.MAXIMUM_ENEMY_POOL);
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private Enemy CreateEnemy()
    {
        return Instantiate(enemyPrefab);
    }

    private void OnGetEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private void OnReleaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void OnDestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    public Enemy GetEnemy()
    {

        return enemyPool.Get();
    }

    public void ReleaseEnemy(Enemy enemy)
    {
        enemyPool.Release(enemy);
    }
}