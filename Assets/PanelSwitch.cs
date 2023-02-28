using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelSwitch : MonoBehaviour
{
    public GameObject GameObject;
    public GameObject powerRequiredText;
    public bool switchPowered;
    public bool door;
    public bool platform;
    public bool doorLock;

    private bool triggered;

    private void Start()
    {
        if (powerRequiredText != null)
        {
            powerRequiredText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (switchPowered)
            {
                if (Input.GetKeyUp("Interact"))
                {
                    triggered = true;
                }
            }

            if (!switchPowered)
            {
                if (powerRequiredText != null)
                {
                    powerRequiredText.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (powerRequiredText != null)
        {
            powerRequiredText.SetActive(false);
        }
    }

    private void Update()
    {
        
        if (platform && triggered)
        {
            GameObject.GetComponent<Animator>().SetBool("PlatformTriggered", true);
        }
    }
}
