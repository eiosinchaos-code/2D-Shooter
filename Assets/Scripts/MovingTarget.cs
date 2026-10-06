using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingTarget : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
