using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public Scoring scoring;
    public ScannerEffect scannerEffect;
    public bool isGrounded;
    public LayerMask groundLayer;
    
    public Vector2 inputMovementVector;
    public Vector3 inputAimVector;
    public GameObject mainCamera;

    public Transform hit;
    public Transform miss;

    public float speed = 10;
    public float verticalVelocity = 0;
    public float gravity = -15.0f;

    public float sensitivity = 10;

    public float health = 10;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        GroundedChecker(); //quick groundcheck
        GravityHandler();
        InputHandler();
        FinalMovementHandler();
        
    }

    private void LateUpdate()
    {
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

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            CollisionHandler();
        }

        if(inputMovementVector!= Vector2.zero)
        {
            scannerEffect.scanning = true;
        }

       

    }

    private void CollisionHandler()
    {
        Transform hitTransform = null;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, groundLayer))
        {
            hitTransform = raycastHit.transform;

        }

        if (hitTransform != null)
        {
            if(hitTransform.GetComponent<Wall>() != null)
            {
                StartCoroutine(HitEffect(hit, raycastHit.point));
                scoring.AddScore(1);
               
            }
            else
            {
                StartCoroutine(HitEffect(miss, raycastHit.point));
            }
        }
    }

    private void FinalMovementHandler()
    {
        Vector3 inputDir = new Vector3(inputMovementVector.x, 0, inputMovementVector.y);

        if (inputDir.magnitude > 0.1)
        {
            float targetAngle = mainCamera.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * inputDir;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        Vector3 velocity = new Vector3(0, verticalVelocity, 0);

        characterController.Move(velocity * Time.deltaTime);
    }

    private void GroundedChecker()
    {
        Vector3 spherePos = new Vector3(transform.position.x, (characterController.center.y + transform.position.y) - -.14f - characterController.height / 2.6f,
                            transform.position.z);
        isGrounded = Physics.CheckSphere(spherePos, characterController.radius, groundLayer,
                     QueryTriggerInteraction.Ignore);

    }

    IEnumerator HitEffect(Transform transform, Vector3 point)
    {
        transform.gameObject.SetActive(true);
        transform.position = point;
        yield return new WaitForSeconds(2);
        transform.gameObject.SetActive(false);
        scoring.AddScore(1);
    }
}
