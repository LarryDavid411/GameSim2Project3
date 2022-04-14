using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public GameObject camera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = new Vector3(player.position.x, player.position.y, -10);
        camera.GetComponent<Transform>().position = cameraPosition;
    }
    
}
