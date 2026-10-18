using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements (TextMeshPro)")]
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timerText;

    [Header("Database Settings")]
    private string serverUrl = "http://104.129.130.168/submit_score.php";
    private float matchTimer = 0f;
    private bool isGameOver = false;

    void Start()
    {
        // Populate the UI with data saved from the preferences screen
        if (playerNameText != null)
        {
            playerNameText.text = "Player: " + GameData.playerName;
        }

        if (levelText != null)
        {
            levelText.text = "Level: " + GameData.level;
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            matchTimer += Time.deltaTime;

            // Update UI timer if assigned
            if (timerText != null)
            {
                timerText.text = "Time: " + matchTimer.ToString("F1");
            }
        }
    }

    public void TriggerGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        // Automatically pass GameData values to the server when game over is called
        StartCoroutine(PostScoreRoutine(GameData.playerName, GameData.level, GameData.score, matchTimer));
    }

    private IEnumerator PostScoreRoutine(string playerName, int playerLevel, int playerScore, float playerTime)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", playerName);
        form.AddField("level", playerLevel);
        form.AddField("score", playerScore);
        form.AddField("time", playerTime.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(serverUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to submit score: " + www.error);
            }
            else
            {
                Debug.Log("Score submitted successfully: " + www.downloadHandler.text);
            }
        }
    }
}