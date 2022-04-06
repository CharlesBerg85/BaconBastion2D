using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    private void Awake()
    {
        int numGamesSessions = FindObjectsOfType<GameSession>().Length;

        if(numGamesSessions > 1)
            {
            Destroy(gameObject);
            }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            RestGame();
        }
    }

    private void TakeLife()
    {
        playerLives--;
    }

    private void RestGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
