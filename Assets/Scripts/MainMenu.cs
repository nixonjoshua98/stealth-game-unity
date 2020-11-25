using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        LevelManager.LoadNextLevel();
    }
}
