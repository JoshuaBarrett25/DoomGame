using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public ElevatorDoor elevator;

    private void OnTriggerEnter(Collider other)
    {
        elevator.bossDefeated = true;
    }
}
