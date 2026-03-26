using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public float time = 30f;
    public TMP_Text timerText, scoreText;
    public bool isRunning = false;

    public GameObject bot, scoreSign;

    private List<Animator> botList;

    public List<float> impacts;
    public float score;
    public int scoreTotal;
    void Awake()
    {
        botList = new List<Animator>();
        foreach (Animator botAnim in GameObject.FindObjectsByType<Animator>(FindObjectsSortMode.None))
        {
            botList.Add(botAnim);
        }

        impacts = new List<float>();

        scoreSign.SetActive(false);
    }

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
            time -= Time.deltaTime;

            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            timerText.text = "Time: " + timeSpan.Seconds + "s";
        }

        if (time <= 0f)
        {
            isRunning = false;

            foreach (Animator nav in botList)
            {
                if (nav.GetComponent<NavMovement>().enabled == true)
                {
                    nav.GetComponent<NavMovement>().enabled = false;
                }
            }

            scoreSign.SetActive(true);
            score = impacts.Sum();
            scoreTotal = Mathf.RoundToInt(score);
            scoreText.text = "Score: " + scoreTotal;
        }

        if (Input.GetKeyDown(KeyCode.Space) && botList[0].enabled == false && isRunning == true)
        {
            GameObject newBot = Instantiate(bot);
            botList.Add(newBot.GetComponent<Animator>());

            foreach (Animator ragdoll in botList)
            {
                if (ragdoll.enabled == false)
                {
                    botList.Remove(ragdoll);
                    break;
                }
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Exited Game");
    }
}
