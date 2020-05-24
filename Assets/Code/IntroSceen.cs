using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceen : MonoBehaviour
{
    public GameObject rays;
    public AudioSource buttonClickedSound;
    public void StartButtonPressed()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        buttonClickedSound.Play();
        rays.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("SampleScene");
    }
}
