using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    public GameObject LevelWinGo;
    public GameObject InGameUIGo;

    public Text LevelWinScoreText;

    void Update()
    {
        DeclareLevelWin();
    }

    void DeclareLevelWin()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0 && LevelStartUp.gameStart == true)
        {
            //yield return new WaitForSeconds(.1f);

            SceneManager.LoadScene("LevelWin");
            /*
            LevelWinGo.SetActive(true);
            InGameUIGo.SetActive(false);

            LevelWinScoreUpdate();
            GlobalManager.levelWinStatus = true;
            */
        }
    }

    void LevelWinScoreUpdate()
    {
        LevelWinScoreText.text = GlobalStats.levelScore + " $";
    }
}
