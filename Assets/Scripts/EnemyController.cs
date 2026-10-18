using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats & Combat")]
    public int health = 20;
    public GameObject explosionPrefab;
    public GameObject bullet;

    [Header("Movement & Roaming")]
    public float moveSpeed = 2f;
    public float direction = 1.0f;
    private float shootingTimer;
    private bool canShoot = true;

    private bool isBlinking = false;
    private float blinkTimer = 0f;
    private Color previousColor;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (GameData.enemySpeed > 0)
        {
            moveSpeed = GameData.enemySpeed;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPortPosition.x <= 0.05f)
        {
            direction = 1f;
            viewPortPosition.x = 0.05f;
            transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);
        }
        else if (viewPortPosition.x >= 0.95f)
        {
            direction = -1f;
            viewPortPosition.x = 0.95f;
            transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);
        }

        DetectAndShootPlayer();

        if (isBlinking)
        {
            blinkTimer += Time.deltaTime;
            if (blinkTimer >= 0.2f)
            {
                isBlinking = false;
                if (spriteRenderer != null) spriteRenderer.color = previousColor;
                blinkTimer = 0f;
            }
        }
    }

    void DetectAndShootPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 15f);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player") || hit.collider.name == "player")
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
        if (canShoot && bullet != null)
        {
            GameObject b = Instantiate(bullet, transform.position + Vector3.down * 1.5f, Quaternion.identity);

            Bullet bulletScript = b.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.isPlayerBullet = false;
            }

            if (b.GetComponent<Rigidbody2D>() != null)
            {
                b.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 300f);
            }
            canShoot = false;
            shootingTimer = 0f;
        }
    }

    public void GotHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyTarget();
            return;
        }

        if (spriteRenderer != null)
        {
            previousColor = spriteRenderer.color;
            spriteRenderer.color = Color.blue;
            isBlinking = true;
        }
    }

    void DestroyTarget()
    {
        if (explosionPrefab != null)
        {
            GameObject exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
        }
        Destroy(gameObject);
    }
}