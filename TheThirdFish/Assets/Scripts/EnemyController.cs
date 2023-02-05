using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float detectRadius = 10f;
    public float moveSpeed = 5f;
    private float destroyTime = 5.0f;
    private float timer = 0.0f;

    public LayerMask pooplayer;

    private Transform poop;
    private Vector3 randomDirection;

    void Start()
    {
        poop = GameObject.FindWithTag("Poop").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, poop.position);

        if (distanceToPlayer <= detectRadius)
        {
            Vector3 directionToPlayer = (poop.position - transform.position).normalized;
            randomDirection = directionToPlayer + Random.onUnitSphere * 0.5f;
            transform.position = Vector3.Lerp(transform.position, transform.position + randomDirection, moveSpeed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= destroyTime)
        {
            Destroy(gameObject);
        }

        SphereCollider collider = GetComponent<SphereCollider>();

        Vector3 spherePos = new Vector3(transform.position.x, transform.position.y,
                           transform.position.z);
      if(Physics.CheckSphere(spherePos, collider.radius, pooplayer,
                     QueryTriggerInteraction.Ignore))
        {
            Destroy(gameObject);
        }
    }

}
