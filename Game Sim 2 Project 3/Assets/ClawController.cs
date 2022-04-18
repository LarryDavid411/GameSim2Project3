using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "LandingPad")
        {
            player.GetComponent<PlayerController>().hitWall = true;
        }

        if (other.gameObject.tag == "ClawObject")
        {
            
            // grab with claw
        }
        
        //if 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
