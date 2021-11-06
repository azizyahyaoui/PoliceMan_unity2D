using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool gameIsPaused = false;


    public GameObject pauseMenuUI;
    public GameObject settingsUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        ControlPlayer.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        ControlPlayer.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void ButtonMainMenu()
    {
        GameManager.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("Main_Scene");
    }

    public void OpenSettingsWindow()
    {
        settingsUI.SetActive(true);
 
    }

    public void CloseSettingsWindow()
    {
        settingsUI.SetActive(false);
    }

}
