using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        if (coll.gameObject.CompareTag("target"))
        {
            // Deal damage to the target's health script (takes 2 hits since health is 20 and damage is 10)
            coll.gameObject.GetComponent<ManageTargetHealth>()?.gotHit(10);

            // Only destroy the bullet (the target will destroy itself when health hits 0)
            Destroy(gameObject);
        }
    }
}