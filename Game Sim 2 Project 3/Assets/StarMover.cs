using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMover : MonoBehaviour
{
    public Vector3 starVelocity;

    private float lifeTimer;

    private float timer;

    public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        //lifeTimer = 10;
    }

    
    // Update is called once per frame
    void Update()
    {
        
        
        // timer += Time.deltaTime;
        // gameObject.transform.position += starVelocity;
        // if (timer > lifeTimer)
        // {
        //     
        // }
        //
        // if (destroy)
        // {
        //     Destroy(gameObject, 14);
        //
        // }
        
    }
}
