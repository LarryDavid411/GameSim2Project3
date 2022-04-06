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
    private Vector2 accelleration;
    private Vector3 velocity;

    //public Vector2 position;
    private float movementTimerRight;
    private float movementTimerLeft;
    private float movementTimerUp;
    private float movementTimerDown;
    
    public float movementDuration;

    public void MovePlayer()
    {
        //float z = Input.GetAxis("Vertical");
        //float x = Input.GetAxis("Horizontal");  
        velocity.x += accelleration.x * Time.deltaTime;
        velocity.y += accelleration.y * Time.deltaTime;
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
                //Vector3 lerp = Vector3.Lerp(0f, 20f, time);
                accelleration.x = Mathf.Lerp(0f, 20f, time);
                Debug.Log(accelleration.x);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movementTimerLeft += Time.deltaTime;
                float time = movementTimerLeft / movementDuration;
               
               //Debug.Log("LeftArrow");
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movementTimerUp += Time.deltaTime;
                float time = movementTimerUp / movementDuration;
                
                //Debug.Log("UpArrow");
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movementTimerDown += Time.deltaTime;
                float time = movementTimerDown / movementDuration;
                
                //Debug.Log("DownArrow");
            }
            
            // Key Released
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
               movementTimerRight = 0;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                movementTimerLeft = 0;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                movementTimerUp = 0;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
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
