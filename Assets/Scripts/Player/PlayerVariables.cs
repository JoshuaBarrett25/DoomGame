using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVariables : MonoBehaviour
{
    public AudioSource pain;
    public AudioSource death;
    public int health = 100;
    public int currentWeaponDamage;
    public bool[] gunsAcquired;
    public int[] ammo;
    public int[] damage;

    float shootDuration = 0.0f;
    public float[] cockedTimer;
    public Weapons weaponEquipped;
    public GameObject currentWeaponSprite;
    public GameObject[] weaponObjects;
    public GameObject SwitchToWeapon;
    public GameObject[] pistolAnimation;
    public GameObject[] shotgunAnimation;
    public GameObject[] rocketAnimation;
    private bool switched = true;
    private int animationIndex = 0;

    public bool isShooting = false;

    public enum Weapons
    {
        PISTOL,
        SHOTGUN,
        ROCKET
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        pain.Play();
    }

    private void Update()
    {
        if (isShooting && weaponEquipped == Weapons.PISTOL)
        {
            ShootPistol();
        }

        if (isShooting && weaponEquipped == Weapons.SHOTGUN)
        {
            ShootShotgun();
        }

        if (isShooting && weaponEquipped == Weapons.ROCKET)
        {
            ShootRocket();
        }

        NumSwap();
        Debug.Log(health);
        if (health <= 0)
        {
            death.Play();
            SceneManager.LoadScene(2);
        }

        Debug.Log(weaponEquipped);

        switch (weaponEquipped)
        {
            case Weapons.PISTOL:
                if (switched)
                {
                    currentWeaponSprite.gameObject.SetActive(false);
                    currentWeaponSprite = weaponObjects[(int)Weapons.PISTOL];
                    currentWeaponSprite.gameObject.SetActive(true);
                    currentWeaponDamage = damage[(int)Weapons.PISTOL];
                    switched = false;
                }

                else
                {
                    if (Input.GetAxis("Mouse ScrollWheel") < 0f)

                    {
                        if (gunsAcquired[(int)Weapons.ROCKET] && !isShooting)
                        {
                            weaponEquipped = Weapons.ROCKET;
                            switched = true;
                        }
                    }

                    if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                    {
                        if (gunsAcquired[(int)Weapons.SHOTGUN] && !isShooting)
                        {
                            weaponEquipped = Weapons.SHOTGUN;
                            switched = true;
                        }
                    }
                }
                break;

            case Weapons.SHOTGUN:
                if (switched)
                {
                    currentWeaponSprite.gameObject.SetActive(false);
                    currentWeaponSprite = weaponObjects[(int)Weapons.SHOTGUN];
                    currentWeaponSprite.gameObject.SetActive(true);
                    currentWeaponDamage = damage[(int)Weapons.SHOTGUN];
                    switched = false;
                }

                else
                {
                    if (Input.GetAxis("Mouse ScrollWheel") < 0f && !isShooting)
                    {
                        weaponEquipped = Weapons.PISTOL;
                        switched = true;
                    }

                    if (Input.GetAxis("Mouse ScrollWheel") > 0f && !isShooting && gunsAcquired[(int)Weapons.ROCKET])
                    {
                        weaponEquipped = Weapons.ROCKET;
                        switched = true;
                    }
                }
                break;

            case Weapons.ROCKET:
                if (switched)
                {
                    currentWeaponSprite.gameObject.SetActive(false);
                    currentWeaponSprite = weaponObjects[(int)Weapons.ROCKET];
                    currentWeaponSprite.gameObject.SetActive(true);
                    currentWeaponDamage = damage[(int)Weapons.ROCKET];
                    switched = false;
                }

                else
                {
                    if (Input.GetAxis("Mouse ScrollWheel") < 0f && !isShooting && gunsAcquired[(int)Weapons.ROCKET])
                    {
                        weaponEquipped = Weapons.SHOTGUN;
                        switched = true;
                    }

                    if (Input.GetAxis("Mouse ScrollWheel") > 0f && !isShooting)
                    {
                        weaponEquipped = Weapons.PISTOL;
                        switched = true;
                    }
                }
                break;
        }
    }



    void NumSwap()
    {
        if (Input.GetButtonUp("Weapon1"))
        {
            weaponEquipped = Weapons.PISTOL;
        }

        if (Input.GetButtonUp("Weapon2") && gunsAcquired[(int)Weapons.SHOTGUN])
        {
            weaponEquipped = Weapons.SHOTGUN;
        }

        if (Input.GetButtonUp("Weapon3") && gunsAcquired[(int)Weapons.ROCKET])
        {
            weaponEquipped = Weapons.ROCKET;
        }
    }


    public void ShootPistol()
    {
        shootDuration += Time.deltaTime;
        if (shootDuration >= cockedTimer[(int)Weapons.PISTOL] / pistolAnimation.Length && shootDuration < cockedTimer[(int)Weapons.PISTOL])
        {
            pistolAnimation[0].SetActive(false);
            pistolAnimation[1].SetActive(true);
        }
        else if (shootDuration > cockedTimer[(int)Weapons.PISTOL])
        {
            pistolAnimation[1].SetActive(false);
            pistolAnimation[0].SetActive(true);
            isShooting = false;
            shootDuration = 0;
        }
    }


    public void ShootShotgun()
    {
        shootDuration += Time.deltaTime;
        if (shootDuration >= cockedTimer[(int)Weapons.SHOTGUN] / 4 && shootDuration < cockedTimer[(int)Weapons.SHOTGUN])
        {
            shotgunAnimation[animationIndex].SetActive(false);
            animationIndex += 1;
            shotgunAnimation[animationIndex].SetActive(true);
            shootDuration = 0;
        }

        if (animationIndex == 4)
        {
            animationIndex = 0;
            shotgunAnimation[4].SetActive(false);
            shotgunAnimation[0].SetActive(true);
            isShooting = false;
            shootDuration = 0;
        }
    }


    public void ShootRocket()
    {
        shootDuration += Time.deltaTime;
        if (shootDuration >= cockedTimer[(int)Weapons.ROCKET] / 3 && shootDuration < cockedTimer[(int)Weapons.ROCKET])
        {
            rocketAnimation[animationIndex].SetActive(false);
            animationIndex += 1;
            if (animationIndex < rocketAnimation.Length)
            {
                rocketAnimation[animationIndex].SetActive(true);
            }
            shootDuration = 0;
        }

        if (animationIndex >= 3)
        {
            animationIndex = 0;
            rocketAnimation[2].SetActive(false);
            rocketAnimation[0].SetActive(true);
            isShooting = false;
            shootDuration = 0;
        }
    }
}
