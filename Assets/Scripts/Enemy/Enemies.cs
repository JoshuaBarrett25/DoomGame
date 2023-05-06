using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class Enemies : MonoBehaviour
{
    public enum EnemyState
    {
        STATIONARY,
        PATROLLING,
        ALERT,
        CHASING,
        ATTACKING,
    }

    public AudioSource clip;
    public GameSettings gameSettings;
    public Transform startPoint;
    public GameObject player;
    public GameObject detectionCone;
    public NavMeshAgent navAgent;
    public SpriteRenderer sprite;
    public Rigidbody rb;
    public CapsuleCollider collider;
    public PlayerVariables playerVars;

    private void Start()
    {
        player = GameObject.Find("Player");
        gameSettings = FindObjectOfType<GameSettings>();
    }

    public EnemyState neutralState;
    public float walkSpeed;
    public float chaseSpeed;
    public float attackSpeed;
    public bool playerDetected;

    public int damageValues;

    public bool canAttack = true;

    public virtual void Attack(int damage)
    {
        clip.Play();
        playerVars.TakeDamage(damage * gameSettings.damageScalar[gameSettings.damageIndex]);
        Debug.Log("Attack!");
    }
}
