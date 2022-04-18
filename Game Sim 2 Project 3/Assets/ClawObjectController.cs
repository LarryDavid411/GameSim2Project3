using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawObjectController : MonoBehaviour
{

    public GameObject playerClaw;
    public GameObject clawGrabber;
    public GameObject clawObjects;
    public bool objectGrabbed;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            }
        }
        // if (!objectGrabbed)
        // {
        //     this.gameObject.transform.parent = clawObjects.transform;
        // }
    }
}
