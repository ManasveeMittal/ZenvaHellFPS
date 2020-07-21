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

        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Level3");
    }

    public void QuitGame()
    {
        clickFX.Play();
        Application.Quit();
    }
}
