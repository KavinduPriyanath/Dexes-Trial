using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{

    [SerializeField] private PauseMenu pause;

    private void Start()
    {
        pause.gameOver = true;
    }

    public void RetryAgain ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

}
