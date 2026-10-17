using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text levelText;
    public TMP_Text timerText;
    public GameObject pauseMenuUI;

    private bool isPaused = false;
    private float countUpTimer = 0f;

    void Start()
    {
        GameData.survivalTime = 0f;
        GameData.score = 0;

        if (playerNameText != null) playerNameText.text = "Player: " + GameData.playerName;
        if (levelText != null) levelText.text = "Level: " + GameData.level;
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // Pause / Resume with ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }

        if (!isPaused)
        {
            countUpTimer += Time.deltaTime;
            GameData.survivalTime = countUpTimer;
            if (timerText != null)
            {
                timerText.text = "Time: " + countUpTimer.ToString("F1") + "s";
            }
        }

        // Allow player to quit/stop early (e.g., pressing 'Q')
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EndGameAndExit();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pauseMenuUI != null) pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
    }

    public void EndGameAndExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("exit");
    }
}