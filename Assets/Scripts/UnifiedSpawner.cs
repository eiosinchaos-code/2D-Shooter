using UnityEngine;

public class UnifiedSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject spawnPrefab;
    public string targetTag = "asteroid"; // Use "asteroid" or "Enemy" depending on the spawner object
    public int maxActiveObjects = 5;

    private float gameTimer = 0f;
    private float nextSpawnTime = 5f; // First spawn triggers exactly at 5 seconds

    void Start()
    {
        nextSpawnTime = 5f;
    }

    void Update()
    {
        gameTimer += Time.deltaTime;

        if (gameTimer >= nextSpawnTime)
        {
            TrySpawnObject();

            // Calculate interval based on items per minute (1 to 15 range)
            float ratePerMinute = Mathf.Clamp(GameData.spawnRatePerMinute, 1f, 15f);
            float intervalSeconds = 60f / ratePerMinute;

            nextSpawnTime = gameTimer + intervalSeconds;
        }
    }

    void TrySpawnObject()
    {
        GameObject[] activeObjects = GameObject.FindGameObjectsWithTag(targetTag);

        if (activeObjects.Length < maxActiveObjects && spawnPrefab != null)
        {
            float randomX = Random.Range(-7f, 7f);
            Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0f);
            Instantiate(spawnPrefab, spawnPos, Quaternion.identity);
        }
    }
}
