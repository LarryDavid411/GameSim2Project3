using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public float fuel;
    private Vector2 acceleration;
    private Vector3 velocity;

    //public Vector2 position;
    private float movementTimerRight;
    private float movementTimerLeft;
    private float movementTimerUp;
    private float movementTimerDown;
    
    public float movementDuration;

    public void MovePlayer()
    {
        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
        Vector3 movePlayerPosition = new Vector2();
        movePlayerPosition.x = velocity.x * Time.deltaTime;
        movePlayerPosition.y = velocity.y * Time.deltaTime;
        this.gameObject.transform.position += movePlayerPosition;
        
        if (fuel > 0)
        {
            // Key Down
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movementTimerRight += Time.deltaTime;
                float time = movementTimerRight / movementDuration;
                acceleration.x = Mathf.Lerp(0f, 20f, time);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movementTimerLeft += Time.deltaTime;
                float time = movementTimerLeft / movementDuration;
                acceleration.x = -Mathf.Lerp(0f, 20f, time);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movementTimerUp += Time.deltaTime;
                float time = movementTimerUp / movementDuration;
                acceleration.y = Mathf.Lerp(0f, 20f, time);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movementTimerDown += Time.deltaTime;
                float time = movementTimerDown / movementDuration;
                acceleration.y = -Mathf.Lerp(0f, 20f, time);
            }
            
            // Key Released
            if (Input.GetKeyUp(KeyCode.RightArrow))
            { 
               acceleration.x = 0;
               movementTimerRight = 0;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                acceleration.x = 0;
                movementTimerLeft = 0;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                acceleration.y = 0;
                movementTimerUp = 0;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                acceleration.y = 0;
                movementTimerDown = 0;
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
        
    }
}
