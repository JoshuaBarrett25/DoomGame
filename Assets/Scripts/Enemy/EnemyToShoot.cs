using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToShoot : MonoBehaviour
{
    public static EnemyHealth enemy;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = other.gameObject.GetComponent<EnemyHealth>();
            Debug.Log(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemy = null;
    }
}
