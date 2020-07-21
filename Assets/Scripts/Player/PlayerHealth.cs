using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    private int damage = 10;

    public GameObject playerHealthStatus;
    public GameObject InGameUIGo;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GlobalStats.PlayerHP -= damage;
        }
    }
}
