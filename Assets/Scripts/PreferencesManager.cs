using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PreferencesManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Dropdown speedDropdown;
    public TMP_Dropdown healthDropdown;
    public Slider spawnSlider;
    public TMP_Text spawnRateText;

    void Start()
    {
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
        // Save player name
        if (nameInput != null && !string.IsNullOrEmpty(nameInput.text))
        {
            GameData.playerName = nameInput.text;
        }

        // Save enemy speed
        if (speedDropdown != null)
        {
            switch (speedDropdown.value)
            {
                case 0: GameData.enemySpeed = 1f; break;
                case 1: GameData.enemySpeed = 2f; break;
                case 2: GameData.enemySpeed = 4f; break;
            }
        }

        // Save player health / God Mode
        if (healthDropdown != null)
        {
            switch (healthDropdown.value)
            {
                case 0: GameData.playerMaxHealth = 1; break;
                case 1: GameData.playerMaxHealth = 2; break;
                case 2: GameData.playerMaxHealth = 3; break;
                case 3: GameData.playerMaxHealth = 999; break; // God Mode
            }
        }

        // Load the main gameplay scene
        SceneManager.LoadScene("game");
    }
}