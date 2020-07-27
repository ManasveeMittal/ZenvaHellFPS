using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadCurrentLevel : MonoBehaviour
{
    public Text ReloadCurrentLevelText;

    void Start()
    {
        StartCoroutine(LoadNextLevelFunction());
    }

    IEnumerator LoadNextLevelFunction()
    {
        yield return new WaitForSeconds(3f);

        for (int i = 5; i > 0; i--)
        {
            ReloadCurrentLevelText.text = "Loading Next Level in \n" + i;
            yield return new WaitForSeconds(1f);
        }

        string levelName = "Level" + PlayerPrefs.GetInt("levelIndex");
        SceneManager.LoadScene(levelName);
    }
}
