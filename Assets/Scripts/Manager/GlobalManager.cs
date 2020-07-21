using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    public static int currentLevel = 3;
    public static bool levelWinStatus = false;
    public static bool levelLoseStatus = false;

    public static GlobalManager Get()
    {
        return GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
    }


    public void Play(AudioClip clip)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = clip;
        audioSource.Play();

        StartCoroutine(RemoveSoundComponent(audioSource));
    }

    IEnumerator RemoveSoundComponent(AudioSource audioSource)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(audioSource);
    }


    private void Update()
    {
        if(levelWinStatus == true)
        {
            StartCoroutine(LoadNextLevel());
        }
        if (levelLoseStatus == true)
        {
            StartCoroutine(ReloadCurrentLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        levelWinStatus = false;

        yield return new WaitForSeconds(5f);

        currentLevel += 1;
        string NextLevelName = "Level" + currentLevel;
        SceneManager.LoadScene(NextLevelName);

        Debug.Log(NextLevelName + "loaded");
    }

    IEnumerator ReloadCurrentLevel()
    {
        levelLoseStatus = false;

        yield return new WaitForSeconds(5f);

        string currentLevelName = "Level" + currentLevel;
        SceneManager.LoadScene(currentLevelName);

        Debug.Log(currentLevelName + "loaded");

        LevelLose.levelResetStatus = true;
    }


    /*
    public GameObject[] spawnPointHolders;

    public void StartNextLevel()
    {
        if(levelWinStatus == true)
        { 
            StartCoroutine(StartNextLevelDelayed());
        }

    }

    IEnumerator StartNextLevelDelayed()
    {
        Debug.Log("levelWinStatus " + levelWinStatus);
        levelWinStatus = false;
        Debug.Log("levelWinStatus " + levelWinStatus);

        Debug.Log(spawnPointHolders.Length);
        Debug.Log(currentLevel);

        yield return new WaitForSeconds(5f);

        
        spawnPointHolders[currentLevel].SetActive(false);
        Debug.Log(spawnPointHolders[currentLevel].name);

        spawnPointHolders[currentLevel + 1].SetActive(true);
        Debug.Log(spawnPointHolders[currentLevel + 1].name);

        currentLevel += 1;
        Debug.Log(currentLevel);
    }
    */

}
