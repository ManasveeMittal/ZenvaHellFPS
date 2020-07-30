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
            StartCoroutine(EnemyDeathFunction());
        }
    }

    void DamageEnemy(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    IEnumerator EnemyDeathFunction()
    {
        enemyDead = true;

        //StartCoroutine(EnemyDeathAnimation());
        string[] zombieDeathAnimations = {"left_fall", "back_fall", "right_fall" };
        GetComponent<Animator>().Play( zombieDeathAnimations[ Random.Range(0, zombieDeathAnimations.Length) ] );
        yield return new WaitForSeconds(0.5f);



        GlobalStats.levelScore += Random.Range(0, 5) * Random.Range(0, 5) * PlayerPrefs.GetInt("levelIndex") + 20;

        GlobalManager globalManager = GlobalManager.Get();
        globalManager.Play(deathFX);

        Instantiate(deathEffect, transform.position + Vector3.up, transform.rotation, transform.parent.transform);
        //theEnemy.GetComponent<Animator>().Play("EnemyDeath");
        //yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        //GlobalScore.scoreCount += 1000;
        //GlobalComplete.enemyCount += 1;
    }

    //IEnumerator EnemyDeathAnimation()
    //{

    //}
}
