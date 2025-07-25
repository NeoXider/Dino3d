using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;

    public static GameController Instance;
    public UnityEvent OnGameOver;
    public bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        startTime = Time.time;
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        OnGameOver?.Invoke();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    void Update()
    {
        if (timerText != null && !isGameOver)
        {
            TimeSpan elapsed = TimeSpan.FromSeconds(Time.time - startTime);
            timerText.text = string.Format("{0}:{1:00}", (int)elapsed.TotalSeconds, elapsed.Milliseconds / 10);
        }
    }
}