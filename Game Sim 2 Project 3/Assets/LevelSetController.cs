using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetController : MonoBehaviour
{

   // public Vector3 playerStartPosition;

    public GameObject player;

    public GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = levelManager.GetComponent<LevelAttributesController>().playerStartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
