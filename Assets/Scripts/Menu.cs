﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        LevelManager.LoadFirstLevel();
    }

    public void GoToMenu()
    {
        LevelManager.GoToMenu();
    }
}