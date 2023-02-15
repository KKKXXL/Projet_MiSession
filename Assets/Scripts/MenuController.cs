using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject PageIntro;
    public GameObject PageLevel;
    public GameObject PageGameSetting;
    public void BtnIntro()
    {
        MenuPanel.SetActive(false);
        PageIntro.SetActive(true);
    }
    public void BtnNext()
    {
        MenuPanel.SetActive(false);
        PageIntro.SetActive(false);
    }   
    public void BtnSetting()
    {
        MenuPanel.SetActive(false);
        PageGameSetting.SetActive(true);
    }
    public void RetourMainMenu()
    {
        MenuPanel.SetActive(true);
        PageIntro.SetActive(false);
        PageLevel.SetActive(false);
        PageGameSetting.SetActive(false);
    }
public void BtnStart()
    {
        MenuPanel.SetActive(false);
        PageLevel.SetActive(true);
    }

    public void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void newGame()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
