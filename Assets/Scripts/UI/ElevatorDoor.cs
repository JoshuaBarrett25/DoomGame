using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorDoor : MonoBehaviour
{
    public bool bossDefeated;
    public Animator elevatorAnim;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(3);
    }


    private void Update()
    {
        if (bossDefeated)
        {
            elevatorAnim.SetBool("DoorOpen", true);
        }
    }
}
