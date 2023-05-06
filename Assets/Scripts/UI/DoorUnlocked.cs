using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlocked : MonoBehaviour
{
    public AudioSource clip;
    public Animator anim;
    public bool unlocked = false;
    bool open = false;

    private void Update()
    {
        if (unlocked && !open)
        {
            anim.SetBool("DoorUnlocked", true);
            clip.Play();
            open = true;           
        }
    }
}
