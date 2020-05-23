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

    // ver mejorar el sistema de spawn de los enemigos para que no haya demasiados al mismo tiempo y aparezcan de menos a mas
    IEnumerator SpawnEnemies()
    {
        inCooldown = true;
        int rand = Random.Range(minCooldown, maxCooldown);

        yield return new WaitForSeconds(rand);
        Instantiate(Enemys[0],this.gameObject.transform);
       
        inCooldown = false;
    }
}
