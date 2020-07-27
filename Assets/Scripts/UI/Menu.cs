using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource clickFX;
    public GameObject fadeOut;

    public void StartGame()
    {
        StartCoroutine(NewGameRoutine());
    }

    IEnumerator NewGameRoutine()
    {
        clickFX.Play();
        PlayerPrefs.SetInt("levelIndex", 1);

        yield return new WaitForSeconds(0.1f);

        string levelName = "Level" + PlayerPrefs.GetInt("levelIndex");
        SceneManager.LoadScene(levelName);
    }

    public void ReloadSavedGame()
    {
        clickFX.Play();

        string levelName = "Level" + PlayerPrefs.GetInt("levelIndex");
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        clickFX.Play();
        Application.Quit();
    }
}
