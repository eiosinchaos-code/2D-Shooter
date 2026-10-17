using TMPro; // Use TMPro if using TextMeshPro UI elements
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreferencesManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Dropdown speedDropdown;
    public Slider spawnSlider;
    public TMP_Text spawnRateText;

    void Start()
    {
        // Set default UI values
        if (spawnSlider != null)
        {
            spawnSlider.minValue = 1f;
            spawnSlider.maxValue = 15f;
            spawnSlider.value = GameData.spawnRatePerMinute;
            spawnSlider.onValueChanged.AddListener(OnSpawnSliderChanged);
            UpdateSpawnText(spawnSlider.value);
        }
    }

    public void OnSpawnSliderChanged(float value)
    {
        GameData.spawnRatePerMinute = value;
        UpdateSpawnText(value);
    }

    void UpdateSpawnText(float value)
    {
        if (spawnRateText != null)
        {
            spawnRateText.text = "Spawn Rate: " + Mathf.Round(value) + " /min";
        }
    }

    public void SavePreferencesAndStartGame()
    {
        if (nameInput != null && !string.IsNullOrEmpty(nameInput.text))
        {
            GameData.playerName = nameInput.text;
        }

        if (speedDropdown != null)
        {
            // Example dropdown mapping: 0 = Slow (1f), 1 = Normal (2f), 2 = Fast (4f)
            switch (speedDropdown.value)
            {
                case 0: GameData.enemySpeed = 1f; break;
                case 1: GameData.enemySpeed = 2f; break;
                case 2: GameData.enemySpeed = 4f; break;
            }
        }

        SceneManager.LoadScene("game"); // Ensure your main game scene is named "game"
    }
}