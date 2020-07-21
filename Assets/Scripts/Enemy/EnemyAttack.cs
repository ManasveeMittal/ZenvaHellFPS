using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    private AudioSource enemyFX;
    public AudioClip attackFX, deathFX;

    private GameObject playerTarget;
    private float damage = 3f;

    public bool isAttacking = false;
    public bool shouldChase = true;
    public bool shouldUpdate = true;

    //..
    IEnumerator distUpdateCorountine = null;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemyFX = GetComponent<AudioSource>();
        playerTarget = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (!shouldUpdate) return;

        if (!isAttacking)
        {
            float distance = GetActualDistanceFromTarget();

            if (distance <= 20f)
            {
                if (distUpdateCorountine != null)
                {
                    StopCoroutine(distUpdateCorountine);
                }
                agent.destination = playerTarget.transform.position;
            }
            else
            {
                distUpdateCorountine = LateDistanceUpdate(2f);
                StartCoroutine(distUpdateCorountine);
            }
        }

        animator.SetFloat("SpeedMultiplier", agent.speed);

        if (agent.pathPending) return;

        CheckAttack();
    }

    IEnumerator LateDistanceUpdate(float duration)
    {
        agent.destination = playerTarget.transform.position;
        yield return new WaitForSeconds(duration);

        distUpdateCorountine = null;
        yield break;
    }

    float GetActualDistanceFromTarget()
    {
        return Vector3.Distance(playerTarget.transform.position, this.transform.position);
    }

    float origSpeed;

    void CheckAttack()
    {
        float distanceFromTarget = GetActualDistanceFromTarget();
        Vector3 direction = playerTarget.transform.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if(!isAttacking && distanceFromTarget < 2.0f && angle < 60f)
        {
            isAttacking = true;
            shouldChase = false;

            origSpeed = agent.speed;
            agent.speed = 0;

            transform.LookAt(playerTarget.transform);

            enemyFX.PlayOneShot(attackFX);
            animator.SetTrigger("Attack");

            StartCoroutine(ResetAttack());
        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(3f);

        isAttacking = false;
        shouldChase = true;

        agent.speed = origSpeed;

        yield break;
    }

}