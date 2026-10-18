using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DBTest : MonoBehaviour
{
    // Replace this with your backend PHP script URL or test endpoint if you have one set up,
    // or use this structure to verify your web requests are reaching the server.
    private string serverUrl = "http://104.129.130.168/submit_score.php";

    void Start()
    {
        StartCoroutine(SendTestScore("TestPlayer", 1, 100, 45.5f));
    }

    IEnumerator SendTestScore(string playerName, int playerLevel, int playerScore, float playerTime)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", playerName);
        form.AddField("level", playerLevel);
        form.AddField("score", playerScore);
        form.AddField("time", playerTime.ToString()); // Convert float to string here

        using (UnityWebRequest www = UnityWebRequest.Post(serverUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Database Connection Error: " + www.error);
            }
            else
            {
                Debug.Log("Successfully connected and saved to database: " + www.downloadHandler.text);
            }
        }
    }
}