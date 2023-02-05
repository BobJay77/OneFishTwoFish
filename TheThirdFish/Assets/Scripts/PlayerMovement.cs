using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public CharacterController characterController;
    public CinemachineFreeLook cameraController;

    private void Start()
    {
        if (!characterController)
            characterController = GetComponent<CharacterController>();
        if (!cameraController)
            cameraController = FindObjectOfType<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = cameraController.transform.forward * vertical + cameraController.transform.right * horizontal;
        direction = cameraController.transform.TransformDirection(direction);
        direction.y = 0f;
        direction = direction.normalized;

        characterController.Move(direction * speed * Time.deltaTime);

        if (direction.magnitude > 0f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
