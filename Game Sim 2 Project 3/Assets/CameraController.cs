using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public GameObject cameraObject;

    public float cameraChangeSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = new Vector3(player.position.x, player.position.y, -10);
        cameraObject.GetComponent<Transform>().position = cameraPosition;
        if (Input.GetKey(KeyCode.I))
        {
            cameraObject.GetComponent<Camera>().orthographicSize -= (cameraChangeSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.O))
        {
            cameraObject.GetComponent<Camera>().orthographicSize += (cameraChangeSpeed * Time.deltaTime);
        }
    }
    
}
