using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootInterval = 1.0f;
    public float shootingRange = 10.0f;
    private Transform playerTransform;
    private float timeSinceLastShot = 0.0f;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Poop").transform;
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
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
    }
}
