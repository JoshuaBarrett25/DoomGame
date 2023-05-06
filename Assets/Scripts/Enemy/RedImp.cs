using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RedImp : Enemies
{
    //public EnemyHealth enemyHealth;
    float initialAttackTimer = 0.2f;
    bool initialAttack;
    float attackTimer = 0;
    float flipTimer = 0f;
    float flipAt = 0.4f;
    bool flipped = false;
    EnemyState state = 0;

    float lingerLimit = 4.0f;
    public float stayCountdown = 0.0f;


    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
    }

    private void Update()
    {
        
        switch (state)
        {
            case (EnemyState.STATIONARY):
                Debug.Log("Stationary");
                StayStationary();
                navAgent.speed = walkSpeed;
                InChasingRange();
                break;
            case (EnemyState.PATROLLING):
                Debug.Log("Patrolling");
                FlipTexture();
                navAgent.speed = walkSpeed;
                StayStationary();
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
    }


    void StartingState()
    {
        state = neutralState;
    }

    void StayStationary()
    {
        navAgent.SetDestination(startPoint.position);
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
            if (navAgent.remainingDistance < 3.0f)
            {
                Debug.Log("Attacking");
                attackTimer += Time.deltaTime;
                if (attackTimer > initialAttackTimer)
                {
                    walkSpeed = 2;
                    initialAttack = true;
                }
                if (attackTimer > attackSpeed)
                {
                    walkSpeed = 4.5f;
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
