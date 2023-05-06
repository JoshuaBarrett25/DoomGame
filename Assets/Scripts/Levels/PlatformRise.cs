using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRise : MonoBehaviour
{
    Animator animator;
    GameObject platform;
    public bool triggered = false;


    private void Update()
    {
        if (triggered)
        {
            animator.SetBool("PlatformTriggered", true);
        }
    }
}
