using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelSwitch : MonoBehaviour
{
    public PanelSwitch panelToPower;
    public AudioSource audioClip;
    public GameObject GameObject;
    public Animator animator;
    public GameObject powerRequiredText;
    public bool switchPowered;
    public bool powerSwitch;
    public bool door;
    public bool platform;
    public bool doorLock;
    public GameObject powerOnText;
    private bool triggered;

    private void Start()
    {
        if (powerRequiredText != null)
        {
            powerRequiredText.SetActive(false);
        }

        if (powerOnText != null)
        {
            powerOnText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (powerSwitch)
            {
                if (powerOnText != null)
                {
                    powerOnText.SetActive(true);
                }
                if (Input.GetButtonUp("Interact"))
                {

                    audioClip.Play();
                    panelToPower.switchPowered = true;
                    this.GameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
            if (platform)
            {
                if (Input.GetButtonUp("Interact"))
                {
                    audioClip.Play();
                    triggered = true;
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
            if (switchPowered)
            {
                if (Input.GetButtonUp("Interact"))
                {
                    audioClip.Play();
                    triggered = true;
                    this.GameObject.GetComponent<BoxCollider>().enabled = false;
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

        if (powerOnText != null)
        {
            powerOnText.SetActive(false);
        }
    }

    private void Update()
    {
        if (doorLock && triggered)
        {
            GameObject.GetComponent<Animator>().SetBool("DoorUnlocked", true);
        }
        if (platform && triggered)
        {
            GameObject.GetComponent<Animator>().SetBool("PlatformTriggered", true);
        }
    }
}
