using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyGame : MonoBehaviour
{
    public int score = 0;
    public GameObject PageGameSetting;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public static bool GameIsPaused = false;
    public Text scoreText;

    public void addScore(int value)
    {
        this.score += value;
        scoreText.text = "Score:" + score.ToString();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = -0f;
    }
    public void ReStartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BtnMenu(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void BtnSetting()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 0f;
        PageGameSetting.SetActive(true);
        GameIsPaused = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        PageGameSetting.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
