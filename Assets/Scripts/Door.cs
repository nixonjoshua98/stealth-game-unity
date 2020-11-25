using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (LevelManager.IsNextLevel())
            {
                LevelManager.LoadNextLevel();
            }
            else
            {
                LevelManager.GoToMenu();
            }
        }
    }
}
