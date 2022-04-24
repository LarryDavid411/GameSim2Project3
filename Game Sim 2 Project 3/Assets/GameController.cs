using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject playerController;
    public GameObject starController;
    public GameObject levelManager;
    public bool gamePaused;
    public GameObject uiManager;
    public GameObject pauseButton;
    
    void Update()
    {
        PlayerController player = playerController.GetComponent<PlayerController>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseButton.SetActive(true);
            gamePaused = !gamePaused;
            player.ResetFlames();
            player.ResetAccel();
        }

        if (!gamePaused)
        {
            pauseButton.SetActive(false);
            player.MovePlayer(gamePaused);
        }
        

        //StarController star = starController.GetComponent<StarController>();
        //star.MoveAndGenerateStars();

        // LevelController levelController = levelManager.GetComponent<LevelController>();
        // if (levelController.advanceLevel)
        // {
        //     levelController.ChangeLevel();
        //     levelController.advanceLevel = false;
        // }
        


    }
}
