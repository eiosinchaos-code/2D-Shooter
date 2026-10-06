using UnityEngine;

public class SpawnMovingTargets : MonoBehaviour
{
    float timer = 0;
    public GameObject newObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float range = Random.Range(-10, 10);
        Vector3 newPosition = new Vector3(GameObject.Find("player").transform.position.x + range, transform.position.y, 0);
        if (timer >= 1)
        {
            GameObject t = (GameObject)(Instantiate(newObject, newPosition, Quaternion.identity));
            t.GetComponent<ManageTargetHealth>().type = ManageTargetHealth.TARGET_BOULDER;
            timer = 0;
        }
    }
}
