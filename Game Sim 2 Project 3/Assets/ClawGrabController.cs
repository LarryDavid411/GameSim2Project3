using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawGrabController : MonoBehaviour
{
    public bool objectGrabbed;
    public GameObject playerClaw;
    public GameObject clawObjects;
    public bool startCantGrabObjectTimer;
    public float cantGrabObjectTimer;
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.tag == "ClawObject" && !startCantGrabObjectTimer)
        {
           // Debug.Log("hit");
            if (!objectGrabbed)
            {
               // Debug.Log("hit1");
               // other.gameObject.transform.parent = playerClaw.transform;
                objectGrabbed = true;
                other.GetComponent<ClawObjectController>().objectGrabbed = true;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if (startCantGrabObjectTimer)
        {
            cantGrabObjectTimer += Time.deltaTime;
            if (cantGrabObjectTimer > 2)
            {
                cantGrabObjectTimer = 0;
                startCantGrabObjectTimer = !startCantGrabObjectTimer;
            }
        }
        if (objectGrabbed)
        {
            
        }

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (objectGrabbed)
        //     {
        //         Debug.Log("Space");
        //         objectGrabbed = false;
        //         this.gameObject.transform.GetChild(1).GetComponent<ClawObjectController>().objectGrabbed = false;
        //         //release object
        //         // clawObjects.gameObject.transform.parent = clawObjects.transform;
        //     }
        //     
        // }

    }
}
