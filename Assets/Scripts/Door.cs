using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] AudioSource doorSound;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            doorSound.Play();

            if (LevelManager.IsNextLevel())
            {
                Invoke("LoadNextLevel", 0.25f);
            }
            else
            {
                Invoke("LoadExit", 0.25f);
            }
        }
    }

    void LoadExit()
    {
        LevelManager.GoToEndScreen();
    }

    void LoadNextLevel()
    {
        LevelManager.LoadNextLevel();
    }
}
