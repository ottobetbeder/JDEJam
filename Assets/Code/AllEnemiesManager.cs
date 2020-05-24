using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesManager : MonoBehaviour
{
    public List<Transform> EnemySpawnPosition;
    private List<GameObject> enemies;
    private int maxEnemiesInMapAtSameTime;
    [SerializeField]
    private BoosterSpawner boosterSpawner;

    public int[] probEnemiesToAppear; // the sum of this values must be 100

    [SerializeField]
    GameObject[] EnemyPrefabs;

    [SerializeField]
    int maxCooldown;

    [SerializeField]
    int minCooldown;

    private void Start()
    {
        enemies = new List<GameObject>();
        maxEnemiesInMapAtSameTime = 2;
        boosterSpawner.BombBoosterTouched += DestroyAllEnemies;
    }

    bool inCooldown = false;

    void Update()
    {
        if (!inCooldown && enemies.Count < maxEnemiesInMapAtSameTime)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        inCooldown = true;
        Random.seed = (int)System.DateTime.Now.Ticks;

        int rand = Random.Range(minCooldown, maxCooldown);

        int spawnerPositionToUse = Random.Range(0, EnemySpawnPosition.Count-1);

        yield return new WaitForSeconds(rand);

        GameObject enemyToCreate = GetEnemyToInstantiate();
        GameObject newEnemy = Instantiate(enemyToCreate, EnemySpawnPosition[spawnerPositionToUse]);
        enemies.Add(newEnemy);
        newEnemy.GetComponent<EnemyController>().Die += OnEnemyDead;

        inCooldown = false;
    }

    private GameObject GetEnemyToInstantiate()
    {
        int dice = Random.Range(0, 100);
        for (int i = 0; i < probEnemiesToAppear.Length; i++)
        {
            if (dice < probEnemiesToAppear[i])
            {
                return EnemyPrefabs[i];
            }
            else
            {
                dice -= probEnemiesToAppear[i];
            }
        }
        return null;
    }

    private void OnEnemyDead(GameObject deadEnemy)
    {
        deadEnemy.GetComponent<EnemyController>().Die -= OnEnemyDead;
        enemies.Remove(deadEnemy);
    }

    private const int DIF_VALUE_TO_INCRESS = 10;
    private int incressDifValue = DIF_VALUE_TO_INCRESS;
    public void IncreaseDifficulty()
    {
        maxEnemiesInMapAtSameTime++;

        //this incress the prob of harder enemies to appar
        for (int i = 0; i < probEnemiesToAppear.Length; i++)
        {
            if (i == 0)
            {
                probEnemiesToAppear[i] -= incressDifValue;
            }
            else
            {
                if (i != probEnemiesToAppear.Length - 1)
                {
                    probEnemiesToAppear[i] += incressDifValue / i;
                    incressDifValue -= incressDifValue / i;
                }
                else
                {
                    probEnemiesToAppear[i] += incressDifValue;
                    incressDifValue -= incressDifValue;
                }
            }
        }
        int aux = 0;
        //check for mistakes
        for (int i = 0; i < probEnemiesToAppear.Length; i++)
        {
            aux += probEnemiesToAppear[i];
        }
        probEnemiesToAppear[0] +=  (100 - aux);
        incressDifValue = DIF_VALUE_TO_INCRESS;
    }

    private void DestroyAllEnemies()
    {
        foreach (GameObject item in enemies)
        {
            item.GetComponent<EnemyController>().DestroyEnemiesAfter(0.1f);
        }
    }

}
