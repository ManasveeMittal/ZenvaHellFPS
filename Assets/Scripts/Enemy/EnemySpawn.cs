using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    private Transform[] spawnPoints;

    public GameObject enemyGO;

    private int waitTime = 5;
    public Transform EnemyHolder;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(waitTime);
        LevelStartUp.gameStart = true;
        Debug.Log("gameStart " + LevelStartUp.gameStart);

        float[] speeds = new float[] { 1.5f, 2f };

        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        for (int i = 0; i < spawnPoints.Length; i++)
        //for (int i = 0; i < 2; i++) //test purpose
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            GameObject go = Instantiate(enemyGO, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity, EnemyHolder);
            go.name = "Zombie" + spawnPointIndex;
            enemyGO.GetComponent<NavMeshAgent>().speed = speeds[Random.Range(0, speeds.Length)];

            yield return new WaitForSeconds(.5f);
        }
    }

}
