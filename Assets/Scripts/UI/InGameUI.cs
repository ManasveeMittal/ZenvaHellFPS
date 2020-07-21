using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text playerScoreText;
    public Text playerHealthText;

    void Update()
    {
        PlayerScoreUpdate();
        PlayerHealthUpdate();
    }

    void PlayerScoreUpdate()
    {
        playerScoreText.text = GlobalStats.levelScore + "$";
    }

    void PlayerHealthUpdate()
    {
        playerHealthText.text = "HP :" + GlobalStats.PlayerHP;
    }

}
