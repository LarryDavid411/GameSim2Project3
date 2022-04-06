using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject playerController;

    //private PlayerController playerObject = new PlayerController();
    // Start is called before the first frame update

    // private PlayerController playerObject = player.GetComponent<PlayerController>();
    //
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController player = playerController.GetComponent<PlayerController>();
        player.MovePlayer();
    }
}
