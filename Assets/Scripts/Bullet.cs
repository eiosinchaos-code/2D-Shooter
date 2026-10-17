using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isPlayerBullet = true; // Check this for player bullets, uncheck for enemy bullets

    void Start()
    {
        // Automatically destroy the bullet after 10 seconds if it hits nothing
        Destroy(gameObject, 10f);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (isPlayerBullet)
        {
            // Player bullets should only damage targets or NPCs
            if (coll.gameObject.CompareTag("target") || coll.gameObject.CompareTag("npc"))
            {
                coll.gameObject.GetComponent<ManageTargetHealth>()?.gotHit(10);
                Destroy(gameObject);
            }
        }
        else
        {
            // Enemy bullets should only affect the player
            if (coll.gameObject.CompareTag("Player") || coll.gameObject.name == "player")
            {
                Destroy(gameObject);
            }
        }
    }
}