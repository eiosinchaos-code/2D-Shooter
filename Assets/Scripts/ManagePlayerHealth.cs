using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagePlayerHealth : MonoBehaviour
{
    private int currentHealth;

    void Start()
    {
        currentHealth = GameData.playerMaxHealth;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("target") || coll.gameObject.CompareTag("bullet"))
        {
            Destroy(coll.gameObject);

            // If God Mode is active, don't take damage or destroy the player
            if (GameData.playerMaxHealth >= 999)
            {
                Debug.Log("God Mode active: Damage ignored!");
                return;
            }

            currentHealth--;
            if (currentHealth <= 0)
            {
                DestroyPlayer();
            }
        }
    }

    void DestroyPlayer()
    {
        SceneManager.LoadScene("exit"); // Sends player to exit scene when defeated
    }
}