using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public float time = 0f;
    public TMP_Text timerText;
    public bool isRunning = false;

    public Animator pawn;

    void Start()
    {
        isRunning = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (isRunning == true)
        {
            time += Time.deltaTime;

            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            timerText.text = "Time: " + timeSpan.Seconds + "s";
        }

        if (pawn.enabled == false)
        {
            isRunning = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Exited Game");
    }
}
