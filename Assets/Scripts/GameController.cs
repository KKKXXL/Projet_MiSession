using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreTexte;

    public GameObject gameOverPanel;
    public GameObject WinPanel;
    public GameObject pausePanel;
    public static bool GameIsPaused = false;
    public Text winScore;
    public static GameController Instance;
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void UpdateTotalScore()
    {
        this.scoreTexte.text=totalScore.ToString();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void ShowWinPanel()
    {
        WinPanel.SetActive(true);
        this.winScore.text = totalScore.ToString();

    }
    public void ReStartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    public void BtnMenu(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void BtnNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
