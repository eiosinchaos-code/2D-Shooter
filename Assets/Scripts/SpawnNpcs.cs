using UnityEngine;
public class SpawnNpcs : MonoBehaviour
{
    public GameObject npc1;
    public float respawnTime = 1f; // You can now adjust this in the Inspector
    private float timer;
    float spawnInterval = 60f / GameData.spawnRatePerMinute;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= respawnTime)
        {
            timer = 0f;
            SpawnNPC(npc1);
        }
    }

    void SpawnNPC(GameObject typeOfNPC)
    {
        float range = Random.Range(-10f, 10f);

        Vector3 newPosition = new Vector3(
            GameObject.Find("player").transform.position.x + range,
            transform.position.y,
            0
        );

        GameObject newNPC = Instantiate(typeOfNPC, newPosition, Quaternion.identity);
        newNPC.transform.Rotate(0, 0, 180);
        newNPC.name = "npc1";
    }
}