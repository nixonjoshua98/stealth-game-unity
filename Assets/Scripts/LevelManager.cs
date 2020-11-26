using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
    const int LEVEL_ONE = 2;
    const int MAX_LEVEL = 11;

    public static bool IsNextLevel()
    {
        return (SceneManager.GetActiveScene().buildIndex + 1) <= MAX_LEVEL;
    }

    public static void LoadFirstLevel() { SceneManager.LoadSceneAsync(LEVEL_ONE); }

    public static void GoToMenu() { SceneManager.LoadSceneAsync(0); }

    public static void GoToEndScreen() { SceneManager.LoadSceneAsync(1); }

    public static void LoadNextLevel()
    {
        int newLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if (IsNextLevel())
        {
            SceneManager.LoadSceneAsync(newLevel);
        }
    }

    public static void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
