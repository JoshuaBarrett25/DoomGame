using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Enemies enemies;
    public int health;
    public SpriteRenderer explosionObject;
    public Sprite[] explosionOnHit;
    private int index;
    private float explosionTimer;
    private bool hit;
    private bool dead;
    public bool canAttack;

    public void EnemyHit(int damage)
    {
        health -= damage;
        if (health > 0)
        {
            var tempColor = explosionObject.color;
            tempColor.a = 255f;
            explosionObject.color = tempColor;
            hit = true;
        }

        if (health <= 0)
        {
            hit = true;
            dead = true;
        }
    }

    private void Update()
    {
        Debug.Log(health);
        if (hit)
        {
            explosionTimer += Time.deltaTime;
            if (!dead && explosionTimer > 0.3f)
            {
                if (index >= explosionOnHit.Length)
                {
                    explosionTimer = 0;
                    index = 0;
                    explosionObject.sprite = explosionOnHit[0];
                    var tempColor = explosionObject.color;
                    tempColor.a = 0f;
                    explosionObject.color = tempColor;
                    hit = false;
                }
                else
                {
                    index++;
                    explosionObject.sprite = explosionOnHit[index];
                    explosionTimer = 0;
                }
            }

            if (dead)
            {
                enemies.navAgent.isStopped = true;
                canAttack = false;
                if (index > explosionOnHit.Length)
                {
                    explosionTimer = 0;
                    index = 0;
                    explosionObject.sprite = explosionOnHit[0];
                    hit = false;
                }
                else
                {
                    Destroy(enemies.startPoint.gameObject);
                }
            }
        }
    }
}
