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
    public Animator cameraAnimator;
    public Text timer;
    public float totalTime;
    public int QuantityOfTimesToIncreaseDifficulty;
    public AllEnemiesManager enemiesManager;
    float TimeToIncreaseDifficulty;
    [SerializeField] BoosterSpawner boosterSpawner;

    public bool CanLose = true;

    private void Start()
    {
        playerBase.BaseHurt += OnBaseHurt;
        livesText.text = lives.ToString();
        TimeToIncreaseDifficulty = totalTime / 2;
        boosterSpawner.HeartBoosterTouched += WinLife;
    }

    private void Update()
    {
        totalTime -= Time.deltaTime;
        if (totalTime <= 0)
        {
            totalTime = 0;
            SceneManager.LoadScene("Win");
        }
        UpdateLevelTimer(totalTime);

        if (totalTime <= TimeToIncreaseDifficulty && QuantityOfTimesToIncreaseDifficulty > 0)
        {
            enemiesManager.IncreaseDifficulty();
            TimeToIncreaseDifficulty = TimeToIncreaseDifficulty / 2;
            QuantityOfTimesToIncreaseDifficulty--;
        }
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    private void OnBaseHurt()
    {
        lives--;
        if (lives <= 0)
        {
            livesText.text = "0";
            if (CanLose)
            {
                GameOverPanel.SetActive(true);
                StartCoroutine(ResetSceen());
            }
        }
        else
        {
            cameraAnimator.SetTrigger("Shake");
            livesText.text = lives.ToString();
        }
    }

    IEnumerator ResetSceen()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void WinLife()
    {
        if (lives < 3)
        {
            lives++;
            livesText.text = lives.ToString();
        }
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene("Intro");
    }
}
