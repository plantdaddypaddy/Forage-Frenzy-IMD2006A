using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject gamePauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gamePauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gamePauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
