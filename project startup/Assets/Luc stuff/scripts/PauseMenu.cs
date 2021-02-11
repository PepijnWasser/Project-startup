using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        Debug.Log("time paused");
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("loading menu");
        SceneManager.LoadScene("main menu");
        //GameObject.Find("Canvas/main menu").SetActive(true);

    }
    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
}
