using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private int enemyHealth = 5;
    public bool enemyDead = false;
    public AudioClip deathFX;

    public GameObject deathEffect;

    void Update()
    {
        if( enemyHealth <= 0 && enemyDead == false)
        {
            enemyDead = true;

            GlobalStats.levelScore += Random.Range(0, 5) * Random.Range(0, 5) * GlobalStats.levelIndex + 20;

            GlobalManager globalManager = GlobalManager.Get();
            globalManager.Play(deathFX);

            Instantiate(deathEffect, transform.position+Vector3.up, transform.rotation, transform.parent.transform);
            //theEnemy.GetComponent<Animator>().Play("EnemyDeath");
            //yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
            //GlobalScore.scoreCount += 1000;
            //GlobalComplete.enemyCount += 1;
        }
    }

    void DamageEnemy(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }
}
