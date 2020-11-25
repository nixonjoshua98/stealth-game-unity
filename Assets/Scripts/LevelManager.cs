using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
    const int SCENE_OFFSET = 0;

    const float NUM_LEVELS = 10;

    public static bool IsNextLevel()
    {
        return (SCENE_OFFSET + SceneManager.GetActiveScene().buildIndex + 1) <= NUM_LEVELS;
    }

    public static void GoToMenu() { SceneManager.LoadSceneAsync(0); }

    public static void LoadNextLevel()
    {
        int newLevel = SCENE_OFFSET + (SceneManager.GetActiveScene().buildIndex + 1);

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
