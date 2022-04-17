using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject playerController;
    public GameObject starController;
    public GameObject levelManager;
    
    void Update()
    {
        PlayerController player = playerController.GetComponent<PlayerController>();
        player.MovePlayer();

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
