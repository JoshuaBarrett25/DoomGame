using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrigger : MonoBehaviour
{
    public PlayerVariables playerVars;
    private void OnTriggerEnter(Collider other)
    {
        playerVars.health = 0;
            }
}
