using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootInterval = 1.0f;
    public float shootingRange = 10.0f;
    private Transform playerTransform;
    private float timeSinceLastShot = 0.0f;
    public Scoring scoring;

    public LayerMask pooplayer;
    public Player player;


    public float health = 2;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Poop").transform;
        scoring = GameObject.Find("Scoring").GetComponent<Scoring>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) <= shootingRange)
        {
            transform.LookAt(playerTransform);

            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootInterval)
            {
                timeSinceLastShot = 0.0f;
                ShootBullet();
            }
        }
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

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
    }
}
