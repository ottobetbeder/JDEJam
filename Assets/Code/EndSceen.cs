using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ResetGame());
    }
    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Intro");
    }
}
