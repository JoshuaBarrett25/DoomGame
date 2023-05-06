using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    PlayerVariables playerVariables;
    GameObject player;
    public int[] ammoGained = new int[3];

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerVariables = player.GetComponent<PlayerVariables>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < ammoGained.Length; i++)
            {
                playerVariables.ammo[i] += ammoGained[i];
            }

            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.LookAt(player.transform);
    }
}
