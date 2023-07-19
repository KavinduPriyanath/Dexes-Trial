using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;

    public bool gameOver;

    private void Start()
    {
        gameOver = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause ()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
