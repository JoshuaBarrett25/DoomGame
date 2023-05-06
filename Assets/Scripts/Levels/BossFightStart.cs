using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStart : MonoBehaviour
{
    public Animator anim;
    public Boss bossScript;
    bool shutDoor = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("ShutDoor", true);
            bossScript.startFight = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
