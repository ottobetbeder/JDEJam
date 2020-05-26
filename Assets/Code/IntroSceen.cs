using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceen : MonoBehaviour
{
    public GameObject rays;
    public AudioSource buttonClickedSound;
    public GameObject InstructionPanel;
    private int instPanelOn = -1;

    public void StartButtonPressed()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void ExitButtonPressed()
    {
        Application.Quit();
    }

    public void InstructionButtonPressed()
    {
        instPanelOn *= -1;
        InstructionPanel.SetActive(instPanelOn == 1);
    }

    IEnumerator SpawnEnemies()
    {
        buttonClickedSound.Play();
        rays.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("SampleScene");
    }
}
