using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float Sensitivity = 400f;
    public Transform player;
    public Transform mainCam;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xMouse = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        //float yMouse = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        //xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        mainCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * xMouse);
    }
}
