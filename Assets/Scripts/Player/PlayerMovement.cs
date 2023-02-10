using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject player;
    public Camera fpsCamera;
    public CharacterController controller;


    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform ground;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool grounded;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fpsCamera = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(ground.position, groundDistance, groundMask);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
