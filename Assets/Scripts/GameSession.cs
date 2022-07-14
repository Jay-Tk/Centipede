using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        StartGame();
    }

    private void StartGame()
    {
        if(Input.anyKey && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        ResetGameSession();
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
