using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public EnemyHealth enemy;
    public CharacterController controller;
    public PlayerVariables playerVars;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Vector3 velocity;

    public Transform ground;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool grounded;

    public Vector3 move;

    // Update is called once per frame
    void Update()
    {
        if (playerVars.health > 0)
        {
            grounded = Physics.CheckSphere(ground.position, groundDistance, groundMask);

            if (EnemyToShoot.enemy != null)
            {
                enemy = EnemyToShoot.enemy;
            }

            if (EnemyToShoot.enemy == null)
            {
                enemy = null;
            }

            if (grounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);



            if (Input.GetButtonUp("Shoot") && playerVars.weaponEquipped == PlayerVariables.Weapons.PISTOL && !playerVars.isShooting && playerVars.ammo[0] > 0)
            {
                playerVars.ammo[0] -= 1;
                playerVars.isShooting = true;
                if (enemy != null)
                {
                    enemy.EnemyHit(playerVars.currentWeaponDamage);
                }
            }

            if (Input.GetButtonUp("Shoot") && playerVars.weaponEquipped == PlayerVariables.Weapons.SHOTGUN && !playerVars.isShooting && playerVars.ammo[1] > 0)
            {
                playerVars.ammo[1] -= 1;
                playerVars.isShooting = true;
                if (enemy != null)
                {
                    enemy.EnemyHit(playerVars.currentWeaponDamage);
                }
            }

            if (Input.GetButtonUp("Shoot") && playerVars.weaponEquipped == PlayerVariables.Weapons.ROCKET && !playerVars.isShooting && playerVars.ammo[2] > 0)
            {
                playerVars.ammo[2] -= 1;
                playerVars.isShooting = true;
                if (enemy != null)
                {
                    enemy.EnemyHit(playerVars.currentWeaponDamage);
                }
            }
        }
    }
}
