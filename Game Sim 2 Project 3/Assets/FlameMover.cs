using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMover : MonoBehaviour
{

    private float timerSin;
    public Vector2 flamePosition;
    
    public bool destroy;
    public void FlameAnimation()
    {
        timerSin += Time.deltaTime;

        flamePosition.x = Mathf.Sin(timerSin);
        flamePosition.y = timerSin / 10;
        this.gameObject.transform.localPosition = flamePosition;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerSin += Time.deltaTime;
        Debug.Log(Mathf.Sin(timerSin + 10));
        flamePosition.x = (Mathf.Sin(timerSin * 8)) ;
        flamePosition.y = -(timerSin) * 2 - 0.5f;
        this.gameObject.transform.localPosition = flamePosition;
        //Debug.Log(flamePosition);
        if (destroy)
        {
            if (flamePosition.x < 0)
            {
                Destroy(gameObject);
                timerSin = 0;
                flamePosition.x = 0;
                flamePosition.y = 0;
            }
        }
    }
}
