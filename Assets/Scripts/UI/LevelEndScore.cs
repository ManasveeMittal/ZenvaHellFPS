using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndScore : MonoBehaviour
{
    public Text LevelEndScoreText;

    private void Start()
    {
        LevelEndScoreText.text = "Gold : " + GlobalStats.levelScore;
    }
}
