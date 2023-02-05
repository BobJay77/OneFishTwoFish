using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public bool isGrounded;
    public LayerMask groundLayer;
    
    public Vector2 inputMovementVector;
    public GameObject mainCamera;

    public float speed = 10;
    public float verticalVelocity = 0;
    public float gravity = -15.0f;

    public float sensitivity = 10;

    public float health = 10;
    void Update()
    {
        GroundedChecker(); //quick groundcheck
        GravityHandler();
        InputHandler();
        FinalMovementHandler();
    }

    private void LateUpdate()
    {
        CameraMovement(); 
        inputMovementVector = Vector2.zero;
        speed = 0;
       
    }

    private void GravityHandler()
    {
        if (!isGrounded)
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        else
        {
            verticalVelocity = 0;
        }
    }

    private void InputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            inputMovementVector.y = 1;
            speed = 10;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            inputMovementVector.y = -1;
            speed = 10;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputMovementVector.x = -1;
            speed = 10;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            inputMovementVector.x = 1;
            speed = 10;
        }

    }

    private void FinalMovementHandler()
    {
        Vector3 inputDir = new Vector3(inputMovementVector.x, 0, inputMovementVector.y);
        float targetRotation = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
        Vector3 targetMotion = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;

        characterController.Move(targetMotion.normalized * (speed * Time.deltaTime) + new Vector3(0.0f, verticalVelocity, 0.0f) * Time.deltaTime);

    }

    private void GroundedChecker()
    {
        Vector3 spherePos = new Vector3(transform.position.x, (characterController.center.y + transform.position.y) - -.14f - characterController.height / 2.6f,
                            transform.position.z);
        isGrounded = Physics.CheckSphere(spherePos, characterController.radius, groundLayer,
                     QueryTriggerInteraction.Ignore);

    }

    private void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * sensitivity);
    }

   
}
