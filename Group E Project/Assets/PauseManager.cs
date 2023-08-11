using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;

        if (pausePanel != null)
        {
            pausePanel.SetActive(true); 
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }
}
