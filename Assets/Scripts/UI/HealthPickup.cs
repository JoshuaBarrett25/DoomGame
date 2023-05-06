using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerVariables playerVariables;
    GameObject player;
    public int healthGained = 40;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerVariables = player.GetComponent<PlayerVariables>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerVariables.health += healthGained;
            if (playerVariables.health >= 100)
            {
                playerVariables.health = 100;
            }

            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.LookAt(player.transform);
    }
}
