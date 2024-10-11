using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyToSpawn;
    [SerializeField] Material[] skinColorToSpawn;
    [SerializeField] Material[] pantColorToSpawn;
    [SerializeField] Weapon[] weaponToSpawnWith;
    [SerializeField] string[] nameToSpawnWith;
    [SerializeField] Transform transformHolder;
    [SerializeField] int numberOfMaxEnemy = 0;
    [SerializeField] int numberOfMaxEnemyAtATime = 0;
    [SerializeField] int minNumberToStartSpawn = 0;

    private int numberOfEnemiesSpawned = 0;
    private int numberOfEnemyLeft;

    public UnityEvent<int> OnNumberOfEnemyDecrease;

    public static EnemySpawner Instance { get; private set; }
    public int NumberOfEnemyLeft { get => numberOfEnemyLeft; private set { } }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        numberOfEnemyLeft = numberOfMaxEnemy;
    }
    private void OnDestroy()
    {
        GameManager.Instance.onStateChange.RemoveListener(SelfActive);
    }
    private void OnEnable()
    {
        GameManager.Instance.onStateChange.AddListener(SelfActive);


        OnNumberOfEnemyDecrease.Invoke(numberOfEnemyLeft);
    }

    private void Update()
    {
        if (Enemy.numberOfEnemyRightnow < numberOfMaxEnemyAtATime && numberOfEnemiesSpawned < numberOfMaxEnemy)
        {
            SpawnEnemy();
            numberOfEnemiesSpawned++;

            numberOfEnemyLeft = numberOfMaxEnemy - Enemy.numberOfEnemyHasDie;

            OnNumberOfEnemyDecrease.Invoke(numberOfEnemyLeft);
        }
    }
    private void SpawnEnemy()
    {
        int randomSkin = Random.Range(0, skinColorToSpawn.Length);
        int randomPant = Random.Range(0, pantColorToSpawn.Length);
        int randomWeapon = Random.Range(0, weaponToSpawnWith.Length);
        int randomPos = Random.Range(0, transformHolder.childCount);
        int randomName = Random.Range(0, nameToSpawnWith.Length);

        Vector3 pos = transformHolder.GetChild(randomPos).position;
        pos = new Vector3(pos.x, enemyToSpawn.transform.position.y, pos.z);

        Enemy newEnemy = Instantiate(enemyToSpawn, pos, Quaternion.identity);
        newEnemy.Initialize(skinColorToSpawn[randomSkin], pantColorToSpawn[randomPant], weaponToSpawnWith[randomWeapon], transformHolder, nameToSpawnWith[randomName]);
    }
    private void SelfActive(Enum.GameState gameState)
    {
        if(gameState == Enum.GameState.NormalPVP)
        {
            gameObject.SetActive(true);
        }
        if(gameState == Enum.GameState.Hall)
        {
            gameObject.SetActive(false);
        }
    }
}