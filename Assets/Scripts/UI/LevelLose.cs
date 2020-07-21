using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLose : MonoBehaviour
{
    public GameObject LevelLoseGo;
    public GameObject InGameUIGo;

    public static bool levelResetStatus = false;

    void Update()
    {
        StartCoroutine(DeclareLevelLose());

        if(levelResetStatus == true)
        {
            ResetGaneOnLevelLose();
        }
    }


    IEnumerator DeclareLevelLose()

    {
        if (GlobalStats.PlayerHP <= 0)
        {

            SceneManager.LoadScene("LevelLose");

            yield return new WaitForSeconds(.01f);
            /*
            LevelLoseGo.SetActive(true);
            InGameUIGo.SetActive(false);

            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<HandgunFire>().enabled = false;

            yield return new WaitForSeconds(3f);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                go.SetActive(false);
            }

            GlobalManager.levelLoseStatus = true;
            */
        }
    }

    void ResetGaneOnLevelLose()
    {
        LevelLoseGo.SetActive(false);
        InGameUIGo.SetActive(true);

        GlobalStats.PlayerHP = 100;
        GlobalStats.magazineAmmo = 9;
        GlobalStats.levelScore = 0;

        LevelStartUp.gameStart = false;

        GameObject.FindWithTag("Player").GetComponent<HandgunFire>().enabled = true;

        levelResetStatus = false;
    }
}
