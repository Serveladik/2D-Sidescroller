using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI timerCounterText;
    public TextMeshProUGUI scoreCounterText;
    public TextMeshProUGUI bestScoreCounterText;

    bool isGameFinished = false;
    public GameObject restartButton;


    float timer;
    int score = 0;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/HighScoreFile.json");
        JSONNode jsonGet = JSONNode.Parse(jsonData);

        bestScoreCounterText.text = "Best score: " + jsonGet["BestScore"].ToString();
    }
    
    public float Timer
    {
        get
        {
            return timer;
        }
        set
        {
            if(value >= 0)
            {
                int d = (int)(value * 100.0f);
                int minutes = d / (60 * 100);
                int seconds = (d % (60 * 100)) / 100;

                timerCounterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            else
            {
                isGameFinished = true;
            }
        }
    }

    public float Score
    {
        get
        {
            return timer;
        }
        set
        {
            timer = value;
            scoreCounterText.text = "Score: " + value.ToString();
        }
    }

    public float currentTime = 0;
    void Update()
    {
        Timer = currentTime;
        currentTime -= Time.deltaTime;

        if(isGameFinished)
        {
            SaveScore();
            restartButton.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void RestartGame()
    {
        isGameFinished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SaveScore()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/HighScoreFile.json");
        JSONNode jsonGet = JSONNode.Parse(jsonData);

        if(jsonGet != null)
        {
            int tempBestScore = jsonGet["BestScore"];
            if(tempBestScore > Score)
            {
                return;
            }
            else
            {
                JSONObject jsonSet = new JSONObject();
                jsonSet.Add("BestScore", Score);
                File.WriteAllText(Application.dataPath + "/HighScoreFile.json", jsonSet.ToString());   

                bestScoreCounterText.text = "Best score: " + jsonGet["BestScore"].ToString();
            }
        }
    }
}
