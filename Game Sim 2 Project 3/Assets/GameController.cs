using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject playerController;
    public GameObject starController;

    //private PlayerController playerObject = new PlayerController();
    // Start is called before the first frame update

    // private PlayerController playerObject = player.GetComponent<PlayerController>();
    //

    // Update is called once per frame
    void Update()
    {
        PlayerController player = playerController.GetComponent<PlayerController>();
        player.MovePlayer();

        StarController star = starController.GetComponent<StarController>();
        //star.MoveAndGenerateStars();
    }
}
