using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Transform sendEnemiesTo;

    [SerializeField]
    GameObject[] Enemys;

    [SerializeField]
    int maxCooldown;

    [SerializeField]
    int minCooldown;

    bool inCooldown = false;

    void Update()
    {
        if (!inCooldown)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        inCooldown = true;
        Instantiate(Enemys[0]);
       int rand = Random.Range(minCooldown, maxCooldown);
       yield return new WaitForSeconds(rand);
       inCooldown = false;
    }
}
