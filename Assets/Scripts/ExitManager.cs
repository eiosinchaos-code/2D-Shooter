using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ExitManager : MonoBehaviour
{
    public TMP_Text resultsText;
    public TMP_Text highScoresText;

    private string updateURL = "http://104.129.130.168/updateShooters.php";
    private string getURL = "http://104.129.130.168/getShooters.php";

    void Start()
    {
        if (resultsText != null)
        {
            resultsText.text = $"Name: {GameData.playerName}\nLevel: {GameData.level}\nScore: {GameData.score}\nTime: {GameData.survivalTime:F1}s";
        }

        StartCoroutine(UploadScoreAndFetchHighScores());
    }

    IEnumerator UploadScoreAndFetchHighScores()
    {
        string url = $"{updateURL}?name={UnityWebRequest.EscapeURL(GameData.playerName)}&level={GameData.level}&score={GameData.score}&time={GameData.survivalTime}";

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error uploading score: " + www.error);
        }

        StartCoroutine(GetTopScores());
    }

    IEnumerator GetTopScores()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURL);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            if (highScoresText != null) highScoresText.text = "Failed to load high scores.";
        }
        else
        {
            if (highScoresText != null)
            {
                string[] lines = www.downloadHandler.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
                string displaytext = "--- TOP 5 LEADERBOARD ---\n";
                int rank = 1;

                foreach (string line in lines)
                {
                    if (rank <= 5)
                    {
                        displaytext += rank + ". " + line + "\n";
                        rank++;
                    }
                }

                highScoresText.text = displaytext;
            }
        }
    }
}