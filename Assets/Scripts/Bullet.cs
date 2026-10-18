using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isPlayerBullet = true;
    public int bulletDamage = 10;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;

        if (isPlayerBullet)
        {
            if (hitObject.CompareTag("asteroid") || hitObject.CompareTag("Enemy"))
            {
                if (hitObject.CompareTag("asteroid"))
                {
                    GameData.score += 1;
                    TargetController target = hitObject.GetComponent<TargetController>();
                    if (target != null)
                    {
                        target.GotHit(bulletDamage);
                    }
                }
                else if (hitObject.CompareTag("Enemy"))
                {
                    GameData.score += 5;
                    EnemyController enemy = hitObject.GetComponent<EnemyController>();
                    if (enemy != null)
                    {
                        enemy.GotHit(bulletDamage);
                    }
                }

                Destroy(gameObject);
            }
        }
        else
        {
            if (hitObject.CompareTag("Player") || hitObject.name == "player")
            {
                Destroy(gameObject);
            }
        }
    }
}