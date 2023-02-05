using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform poop;
    public float range = 23;
    public float spawnRadius = 5f;
    public float spawnInterval = 5f;
    public float health = 3;

    public LayerMask pooplayer;
    public Player player;
    public Scoring scoring;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        scoring = GameObject.Find("Scoring").GetComponent<Scoring>();
        StartCoroutine(Spawn());
        
    }

    private void Update()
    {
        if (health <= 0)
        {
            scoring.AddScore(1);
            Destroy(gameObject);
        }
        SphereCollider collider = GetComponent<SphereCollider>();

        Vector3 spherePos = new Vector3(transform.position.x, transform.position.y,
                           transform.position.z);
        if (Physics.CheckSphere(spherePos, collider.radius, pooplayer,
                       QueryTriggerInteraction.Ignore))
        {
            player.health--;
            Destroy(gameObject);
        }
    }

    private IEnumerator Spawn()
    {
        while (Vector3.Distance(poop.position, transform.position) < range)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
