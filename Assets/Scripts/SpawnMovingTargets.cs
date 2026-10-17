using UnityEngine;

public class SpawnMovingTargets : MonoBehaviour
{
    private float timer = 0f;
    public GameObject newObject;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;

        // Dynamically calculate spawn interval based on the slider value from GameData (1 to 15 per minute)
        float spawnRate = (GameData.spawnRatePerMinute > 0) ? GameData.spawnRatePerMinute : 5f;
        float spawnInterval = 60f / spawnRate;

        if (timer >= spawnInterval)
        {
            float range = Random.Range(-10f, 10f);
            Vector3 newPosition = new Vector3(GameObject.Find("player").transform.position.x + range, transform.position.y, 0);

            GameObject t = Instantiate(newObject, newPosition, Quaternion.identity);
            t.GetComponent<ManageTargetHealth>().type = ManageTargetHealth.TARGET_BOULDER;

            timer = 0f;
        }
    }
}