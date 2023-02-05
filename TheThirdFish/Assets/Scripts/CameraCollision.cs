using System.Collections;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minimumDistance = 0.5f;
    public float smooth = 10.0f;
    public LayerMask collisionLayer;
    private Vector3 direction;
    private Vector3 position;
    private float distance;

    void Start()
    {
        direction = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    void LateUpdate()
    {
        position = transform.parent.position + transform.localPosition;
        RaycastHit hit;

        if (Physics.SphereCast(transform.parent.position, 0.5f, direction, out hit, distance, collisionLayer))
        {
            transform.localPosition = direction * (hit.distance - minimumDistance) * smooth * Time.deltaTime + transform.localPosition;
        }
    }
}
