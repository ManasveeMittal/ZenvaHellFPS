using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelStartUp : MonoBehaviour
{
    private Text startUpText;
    public AudioClip prepare, beep, gameBegins;

    GlobalManager globalManager;

    public GameObject InGameUIGo;
    public GameObject theGun;

    public static bool gameStart;

    public int prepareTime = 5;

    void Start()
    {
        globalManager = GlobalManager.Get();
        globalManager.Play(gameBegins);

        InGameUIGo.SetActive(true);

        GlobalStats.magazineAmmo = 9;
        GlobalStats.PlayerHP = 100;
        GlobalStats.levelScore = 0;

        Debug.Log(SceneManager.GetActiveScene().name + " is loaded");
        Debug.Log("Level  "+ PlayerPrefs.GetInt("levelIndex") + " is loaded");

        gameStart = false;

        startUpText = GetComponent<Text>();
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        for(int i= prepareTime; i>0; i--)
        {
            globalManager.Play(beep);

            startUpText.text = "Prepare to fight....\nBegins at " + i + " seconds.";

            yield return new WaitForSeconds(1f);
        }

        startUpText.text = " FIGHT! ";
        globalManager.Play(prepare);

        yield return new WaitForSeconds(3f);

        theGun.GetComponent<Animator>().Play("FPSHand|Draw");

        this.gameObject.SetActive(false);
    }


}
