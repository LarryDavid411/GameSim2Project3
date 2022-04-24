using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawObjectController : MonoBehaviour
{

    public GameObject playerClaw;
    public GameObject player;
    public GameObject clawGrabber;
    public GameObject clawObjects;
    public bool objectGrabbed;
    public GameObject levelController;

    public Vector3 clawObjectVelocityFromPlayer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ClawObjectLandingPad")
        {
            levelController.GetComponent<LevelAttributesController>().gameObjectInProperLocation = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ClawObjectLandingPad")
        {
            levelController.GetComponent<LevelAttributesController>().gameObjectInProperLocation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ClawObjectLandingPad")
        {
            levelController.GetComponent<LevelAttributesController>().gameObjectInProperLocation = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MoveOutOfPlayerParent()
    {
        if (objectGrabbed)
        {
            this.gameObject.transform.parent = clawObjects.transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectGrabbed)
        {                
            this.gameObject.transform.parent = playerClaw.transform;
            if (Input.GetKey(KeyCode.Space))
            {
                this.gameObject.transform.parent = clawObjects.transform;
                objectGrabbed = false;
                clawGrabber.GetComponent<ClawGrabController>().objectGrabbed = false;
                clawGrabber.GetComponent<ClawGrabController>().startCantGrabObjectTimer = true;
            }

            clawObjectVelocityFromPlayer = player.GetComponent<PlayerController>().velocity;
        }
        else
        {
            Vector3 moveClawObject = new Vector3();
            moveClawObject = clawObjectVelocityFromPlayer;
            this.gameObject.transform.position += moveClawObject * Time.deltaTime;
        }
        // if (!objectGrabbed)
        // {
        //     this.gameObject.transform.parent = clawObjects.transform;
        // }
    }
}
