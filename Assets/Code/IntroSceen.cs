using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceen : MonoBehaviour
{
    public GameObject rays;

    public void StartButtonPressed()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        rays.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene");
    }
}
