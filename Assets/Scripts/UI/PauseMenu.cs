using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuGo;
    public GameObject theGun;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1) //not paused
            {

                Time.timeScale = 0;
                pauseMenuGo.SetActive(true);
                theGun.SetActive(false);

            }
            else if (Time.timeScale == 0)
            {

                Time.timeScale = 1;
                pauseMenuGo.SetActive(false);
                theGun.SetActive(true);
            }
        }
    }

    public void ResumeGameButton()
    {
        Time.timeScale = 1;
        pauseMenuGo.SetActive(false);
    }

    public void ReloadGameButton()
    {
        Time.timeScale = 1;

        GlobalStats.magazineAmmo = 9;

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void HomeMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HomeMenu");
    }

    /*
    private void InvertCursorLockState()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    */
}
