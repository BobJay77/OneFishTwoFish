using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float detectRadius = 10f;
    public float moveSpeed = 5f;
    public float minimumDistance = 1f;

    private Transform player;
    private Vector3 randomDirection;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= minimumDistance)
        {
            Destroy(gameObject);
        }
        else if (distanceToPlayer <= detectRadius)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            randomDirection = directionToPlayer + Random.onUnitSphere * 0.5f;
            transform.position = Vector3.Lerp(transform.position, transform.position + randomDirection, moveSpeed * Time.deltaTime);
        }
    }
}
