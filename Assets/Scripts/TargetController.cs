using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float fallSpeed = 3f;
    public int health = 20;
    public GameObject explosionPrefab;

    private bool isBlinking = false;
    private float blinkTimer = 0f;
    private Color previousColor;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Handle falling movement directly
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Handle hit flash effect
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