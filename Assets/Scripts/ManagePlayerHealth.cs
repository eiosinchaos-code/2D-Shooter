
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagePlayerHealth : MonoBehaviour
{
    private int currentHealth;

    void Start()
    {
        currentHealth = GameData.playerMaxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check whether the player collided with a damaging object.
        if (collision.gameObject.CompareTag("asteroid") ||
            collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("bullet"))
        {
            // God Mode: ignore damage.
            if (GameData.playerMaxHealth >= 999)
            {
                Debug.Log("God Mode active: Damage ignored.");
                return;
            }

            // Destroy the object that hit the player.
            Destroy(collision.gameObject);

            // Reduce player health.
            currentHealth--;

            Debug.Log("Player health: " + currentHealth);

            // Check whether the player has run out of health.
            if (currentHealth <= 0)
            {
                DestroyPlayer();
            }
        }
    }

    void DestroyPlayer()
    {
        SceneManager.LoadScene("exit");
    }
}
