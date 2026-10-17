using UnityEngine;

public class MoveNpc : MonoBehaviour
{
    public GameObject bullet;
    public float direction = 1.0f;
    private float timer;
    private float shootingTimer;
    private bool canShoot = true;
    public float moveSpeed = 1f; // Slower, controlled speed

    void Start()
    {
        // Pull speed from game settings if set
        if (GameData.enemySpeed > 0)
        {
            moveSpeed = GameData.enemySpeed;
        }
    }

    void Update()
    {
        // Continuous smooth movement
        timer += Time.deltaTime;
        transform.Translate(Vector3.left * direction * Time.deltaTime * moveSpeed);
        if (timer >= 2f)
        {
            direction *= -1;
            timer = 0f;
        }

        DetectAndShootPlayer();
    }

    void DetectAndShootPlayer()
    {
        GameObject player = GameObject.Find("player");
        if (player != null)
        {
            float playerXPosition = player.transform.position.x;
            if (transform.position.x < (playerXPosition + 1f) && transform.position.x > (playerXPosition - 1f))
            {
                Shoot();
            }
        }

        if (!canShoot)
        {
            shootingTimer += Time.deltaTime;
            if (shootingTimer >= 0.5f)
            {
                canShoot = true;
                shootingTimer = 0f;
            }
        }
    }

    void Shoot()
    {
        if (canShoot)
        {
            GameObject b = Instantiate(bullet, transform.position + Vector3.down * 1.5f, Quaternion.identity);

            // Mark bullet as an enemy bullet so it doesn't hurt other NPCs
            Bullet bulletScript = b.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.isPlayerBullet = false;
            }

            if (b.GetComponent<Rigidbody2D>() != null)
            {
                b.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 300f); // Controlled bullet force
            }
            canShoot = false;
            shootingTimer = 0f;
        }
    }
}