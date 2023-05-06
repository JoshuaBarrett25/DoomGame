using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public Enemies enemies;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemies.playerDetected = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            enemies.playerDetected = false;
        }
    }
}
