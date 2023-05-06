using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public PlayerVariables playerVars;
    public TMPro.TextMeshProUGUI[] ammoCounters;
    public TMPro.TextMeshProUGUI healthCounter;


    private void Update()
    {
        for (int i = 0; i < ammoCounters.Length; i++)
        {
            ammoCounters[i].text = playerVars.ammo[i].ToString();
        }

        healthCounter.text = playerVars.health.ToString();
    }
}
