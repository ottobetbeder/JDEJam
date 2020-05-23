using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesManager : MonoBehaviour
{
    public List<Transform> EnemySpawnPosition;
    private List<GameObject> enemies;
    private int maxEnemiesInMapAtSameTime;

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
        int rand = Random.Range(minCooldown, maxCooldown);

        int spawnerPositionToUse = Random.Range(0, EnemySpawnPosition.Count-1);

        yield return new WaitForSeconds(rand);

        GameObject newEnemy = Instantiate(EnemyPrefabs[0], EnemySpawnPosition[spawnerPositionToUse]);
        enemies.Add(newEnemy);
        newEnemy.GetComponent<EnemyController>().Die += OnEnemyDead;

        inCooldown = false;
    }

    private void OnEnemyDead(GameObject deadEnemy)
    {
        deadEnemy.GetComponent<EnemyController>().Die -= OnEnemyDead;
        enemies.Remove(deadEnemy);
    }

    public void IncreaseDifficulty()
    {
        maxEnemiesInMapAtSameTime++;
    }

}
