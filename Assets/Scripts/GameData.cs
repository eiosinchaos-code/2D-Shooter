using UnityEngine;

public static class GameData
{
    public static string playerName = "Player";
    public static float enemySpeed = 2f;
    public static float spawnRatePerMinute = 5f; // Slider value (1 to 15)
    public static int playerMaxHealth = 1;       // 1, 2, 3, or 999 for God Mode
    public static int score = 0;
    public static int level = 1;
    public static float survivalTime = 0f;
}