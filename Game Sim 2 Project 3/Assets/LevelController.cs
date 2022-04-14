using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public int currentLevel;

    public GameObject player;
    public GameObject[] levels = new GameObject[5];

    public float levelMovementScale; 
    //private Vector4[] cameraPositionForLevel;

    //public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        // cameraPositionForLevel = new Vector4[10];
        // float levelPositionForY = 0;
        // for (int i = 0; i < 10; i++)
        // {
        //     cameraPositionForLevel[i] = new Vector4(0, levelPositionForY, -10, -1);
        //     levelPositionForY += 200;
        // }
    }

    // Update is called once per frame
    void Update()
    {
       // Vector3 playerMovement = player.GetComponent<PlayerController>().playerPositionDisplacement;
       // levels[currentLevel].transform.position += playerMovement / levelMovementScale;


        //camera.transform.position = cameraPositionForLevel[currentLevel];
    }
}
