using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Cacodemon : Enemies
{
    public Transform[] patrolPoints;
    public int currentDestination;
    float initialAttackTimer = 0.2f;
    bool initialAttack;
    float attackTimer = 0;
    float flipTimer = 0f;
    float flipAt = 0.4f;
    bool flipped = false;
    EnemyState state = (EnemyState)1;

    float lingerLimit = 7.0f;
    public float stayCountdown = 0.0f;

    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
    }

    private void Update()
    {
        switch (state)
        {
            case (EnemyState.PATROLLING):
                Debug.Log("Patrolling");
                FlipTexture();
                navAgent.speed = walkSpeed;
                Patrolling();
                InChasingRange();
                break;

            case (EnemyState.ALERT):
                Debug.Log("Alert");
                FlipTexture();
                navAgent.speed = chaseSpeed;
                StayAround();
                break;

            case (EnemyState.CHASING):
                Debug.Log("Chasing");
                FlipTexture();
                navAgent.speed = chaseSpeed;
                InAttackRange();
                break;

            case (EnemyState.ATTACKING):
                navAgent.speed = chaseSpeed;
                FlipTexture();
                if (canAttack)
                {
                    Attacking();
                }

                break;

        }

        if (playerDetected)
        {
            stayCountdown = 0;
        }
        Debug.Log("Destination: " + currentDestination);
    }

    void StartingState()
    {
        state = neutralState;
    }



    void Patrolling()
    {
        navAgent.SetDestination(patrolPoints[currentDestination].position);
        transform.LookAt(patrolPoints[currentDestination].position);
        if (navAgent.remainingDistance < 2f)
        {
            if (patrolPoints.Length - 1 == currentDestination)
            {
                currentDestination = 0;
            }
            else
            {
                currentDestination += 1;
            }
        }
    }


    void StayAround()
    {
        stayCountdown += Time.deltaTime;
        if (stayCountdown > lingerLimit)
        {
            stayCountdown = 0;
            StartingState();
        }
    }

    void InAttackRange()
    {
        navAgent.SetDestination(player.transform.position);
        if (navAgent.remainingDistance < 3.0f)
        {
            state = EnemyState.ATTACKING;
        }
    }

    void InChasingRange()
    {
        if (playerDetected)
        {
            state = EnemyState.CHASING;
        }
    }

    void Attacking()
    {
        if (playerDetected)
        {
            navAgent.SetDestination(player.transform.position);
            if (navAgent.remainingDistance < 4.0f)
            {
                Debug.Log("Attacking");
                attackTimer += Time.deltaTime;
                if (attackTimer > initialAttackTimer)
                {
                    initialAttack = true;
                }
                if (attackTimer > attackSpeed)
                {
                    Debug.Log("Attacked");
                    Attack(damageValues);
                    attackTimer = 0;
                }
            }
        }

        else
        {
            state = EnemyState.ALERT;
        }
    }



    //Used to "animate" texture
    void FlipTexture()
    {
        flipTimer += Time.deltaTime;
        if (flipTimer > flipAt)
        {
            flipped = !flipped;
            sprite.flipX = flipped;
            flipTimer = 0.0f;
        }
    }



}

