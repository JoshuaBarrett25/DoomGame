using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DoorTrigger : MonoBehaviour
{
    public AudioSource audioClip;
    public GameObject door;
    public GameObject openPosition;
    public GameObject closePosition;

    int doorStateMem = 0;

    enum DoorState
    {
        CLOSED,
        OPENING,
        OPEN
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {                
            audioClip.Play();
            doorStateMem = (int)DoorState.OPENING;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        doorStateMem = (int)DoorState.CLOSED;
    }


    private void Update()
    {
        switch (doorStateMem)
        {
            case (int)DoorState.CLOSED:
                DoorClose();
                break;
            case (int)DoorState.OPENING:
                DoorOpen();
                break;
        }
    }

    private void DoorOpen()
    {
        door.transform.position = Vector3.Lerp(door.transform.position, openPosition.transform.position, Time.deltaTime);
    }


    private void DoorClose()
    {
        door.transform.position = Vector3.Lerp(door.transform.position, closePosition.transform.position, Time.deltaTime);
    }
}
