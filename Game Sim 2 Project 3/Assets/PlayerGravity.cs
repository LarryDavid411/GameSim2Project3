using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{

    public Transform ground;

    public GameObject gravityObject;

    private Vector3 objectPosition;

    public GameObject player;

    private Vector3 playerPosition;

    public float objectMass;
    public float playerMass;


    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray distanceFromPlayer = new Ray(transform.position, transform.);
        float dist = Vector3.Distance(ground.position, gameObject.transform.position);
       // Debug.Log(dist);
       // Debug.Log(ground.position);
        

    }
}
