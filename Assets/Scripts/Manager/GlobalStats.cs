using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalStats : MonoBehaviour
{
    public static int PlayerHP = 100;

    public static int magazineAmmo;
    public static int ammoCount;
    public static int levelScore;
    public static int levelIndex = 3;

    public GameObject magazineAmmoDisplay;
    public GameObject reloadMessage;
    public GameObject InGameUIGo;

    void Update()
    {
        magazineAmmoDisplay.GetComponent<Text>().text = magazineAmmo + " " + "/" + " 9";

        MagazineAmmoStatus();
        ReloadAmmo();
    }
    void MagazineAmmoStatus()
    {
        if (magazineAmmo <= 0 && InGameUIGo.activeSelf ==true)
        {
            reloadMessage.SetActive(true);
        }
        else
        {
            reloadMessage.SetActive(false);
        }
    }

    public void ReloadAmmo()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            magazineAmmo = 9;
        }
    }

    public static GlobalStats Get()
    {
        return GameObject.Find("GlobalManager").GetComponent<GlobalStats>();
    }


}
