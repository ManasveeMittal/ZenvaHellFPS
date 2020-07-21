﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public Text LoadNextLevelText;

    void Start()
    {
        StartCoroutine(LoadNextLevelFunction());
    }

    IEnumerator LoadNextLevelFunction()
    {
        yield return new WaitForSeconds(3f);

        for(int i=5; i>0; i--)
        {
            LoadNextLevelText.text = "Loading Next Level in \n" + i ;
            yield return new WaitForSeconds(1f);
        }

        GlobalManager.currentLevel += 1;
        string levelName = "Level" + GlobalManager.currentLevel;
        SceneManager.LoadScene(levelName);
    }
}
