using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadPreferencesScene()
    {
        SceneManager.LoadScene("preferences");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("game");
    }

    public void LoadExitScene()
    {
        SceneManager.LoadScene("exit");
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("intro");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}