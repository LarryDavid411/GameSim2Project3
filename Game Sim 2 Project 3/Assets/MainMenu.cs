using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float delayGameStartTimer;
    public AudioClip clip;
    public AudioSource source;
    public bool loadGame;
    public AudioClip clip2;
    public AudioSource source2;

    //public void LoadGame();
    
    public void PlayGame()
    {
        //loadGame = true;
        //source.Stop();
        //SceneManager.LoadScene("Level1");
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Update()
    {
        
        if (!source.isPlaying)
        {
            source.Play();
        }
        // if (loadGame)
        // {
        //     if (!source2)
        //     {
        //         source2.Play();
        //     }
        //     
        //     
        //     delayGameStartTimer += Time.deltaTime;
        //     if (delayGameStartTimer > 5.4)
        //     {
        //         loadGame = false;
        //         delayGameStartTimer = 0;
        //         source2.Stop();
        //         SceneManager.LoadScene("Level1");
        //     }
        // }
    }
}
