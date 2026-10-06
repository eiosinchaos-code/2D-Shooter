using UnityEngine;

public class MoveNpc : MonoBehaviour
{
    public GameObject bullet;
    public float direction = 1.0f;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.left * direction * Time.deltaTime * 2);
        if (timer >= 2) { direction *= -1; timer = 0;
        detectPlayer();
    }
        void detectPlayer()
        {
            float playerXPosition = GameObject.Find("player").transform.position.x;
            if (transform.position.x < (playerXPosition + 1) && transform.position.x > (playerXPosition - 1)) Shoot();
        }
    }
    void Shoot()
    {
        GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up * 1.5f, Quaternion.identity));
        b.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 1000);
    }
}
