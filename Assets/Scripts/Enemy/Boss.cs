using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject boss;
    public DoorUnlocked door;
    public GameObject bossUI;
    public bool startFight = false;
    int currentHealth = 1;

    private void Update()
    {
        if (boss == null)
        {
            Debug.Log("Unlocked Door");
            door.unlocked = true;
        }
        if (startFight && boss.GetComponent<EnemyHealth>().health > 0)
        {
            boss.SetActive(true);
            bossUI.SetActive(true);
        }
    }
}
