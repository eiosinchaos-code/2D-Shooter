using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagePlayerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "target")
        {
            Destroy(coll.gameObject);
            DestroyPlayer();
        }
    }
    void DestroyPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
