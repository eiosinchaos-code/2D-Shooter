using UnityEngine;

public class ManageTargetHealth : MonoBehaviour
{
    public int health, type;
    public static int TARGET_BOULDER = 0;
    public bool isBlinking = false;
    public float timer;
    public Color previousColor;
    public GameObject explosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (type == TARGET_BOULDER) health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlinking)
        {
            timer += Time.deltaTime;
            if (timer >= .2)
            {
                isBlinking = false;
                GetComponent<SpriteRenderer>().color = previousColor;
                timer = 0;
            }
        }
    }
    public void gotHit(int damage)
    {
        health -= damage;
        if (health <= 0) destroyTarget();
        previousColor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.blue;
        isBlinking = true;
    }
    public void destroyTarget()
    {
        GameObject exp = (GameObject)(Instantiate(explosion, transform.position, Quaternion.identity));
        Destroy(exp, .5f);
        Destroy(gameObject);
    }
}
