using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives;
    public BaseManager playerBase;
    public Text livesText;
    public GameObject GameOverPanel;

    public bool CanLose = true;

    private void Start()
    {
        playerBase.BaseHurt += OnBaseHurt;
        livesText.text = lives.ToString();
    }

    private void OnBaseHurt()
    {
        lives--;
        if (lives <= 0)
        {
            livesText.text = "0";
            if(CanLose)
            {
                GameOverPanel.SetActive(true);
            StartCoroutine(ResetSceen());
            }
        }
        else
        {
            livesText.text = lives.ToString();
        }
    }

    IEnumerator ResetSceen()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
