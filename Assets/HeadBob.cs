using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField]private bool enableHeadBob = true;

    [SerializeField, Range(0.0f,30.0f)] float bobbingFrequency;
    [SerializeField, Range(0.0f, 0.1f)] float bobbingAmplitude;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform camBobber;

    public PlayerMovement playerMovement;

    private float bobbingStartSpeed = 0.1f;
    [SerializeField]private CharacterController playerController;
    private Vector3 bobStartPos;

    private void Awake()
    {
        bobStartPos = playerCamera.localPosition;
    }

    private void Update()
    {
        if (!enableHeadBob) return;
        isMoving();
        ResetCamPosition();
        playerCamera.LookAt(FocusTarget());
    }

    void ResetCamPosition()
    {
        if (playerCamera.localPosition == bobStartPos) return;
        playerCamera.localPosition = Vector3.Lerp(playerCamera.localPosition, bobStartPos, 1 * Time.deltaTime);
    }

    void isMoving()
    {
        float speed = new Vector3(playerMovement.move.x, 0, playerMovement.move.z).magnitude;
        if (speed < bobbingStartSpeed) return;
        if (!playerController.isGrounded) return;

        bobMotion(stepBob());
    }


    void bobMotion(Vector3 motion)
    {
        playerCamera.localPosition += motion;
    }


    private Vector3 stepBob()
    {
        Vector3 pos = Vector3.zero;
        pos.x += Mathf.Cos(Time.time * bobbingFrequency / 2) * bobbingAmplitude * 2;
        pos.y += Mathf.Sin(Time.time * bobbingFrequency) * bobbingAmplitude;
        return pos;
    }


    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + camBobber.localPosition.y, transform.position.z);
        pos += camBobber.forward * 15.0f;
        return pos;
    }
}
