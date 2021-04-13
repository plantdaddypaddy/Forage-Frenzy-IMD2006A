using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject gamePauseUI;
    public GameObject gameOptionsButtonsUI;
    public GameObject gamePauseButtonsUI;
    public GameObject gameUI;
    public GameObject foxCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                if (gameOptionsButtonsUI.activeSelf)
                {
                    optMenuBack();
                }
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
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gamePauseUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void reSet()
    {
        SceneManager.LoadScene("Main");
    }

    public void setSens (float sens)
    {
        foxCam.GetComponent<cameraController>().rotSpeed = sens;
    }

    public void optMenu()
    {
        gameOptionsButtonsUI.SetActive(true);
        gamePauseButtonsUI.SetActive(false);
    }
    public void optMenuBack()
    {
        gameOptionsButtonsUI.SetActive(false);
        gamePauseButtonsUI.SetActive(true);
    }
}
