using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingTarget : MonoBehaviour
{
    [System.Obsolete]
    void Start()
    {
        // Lowered velocity from 10 to 3 so targets fall at a manageable, steady pace
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 3f;
    }

    void Update()
    {

    }
}