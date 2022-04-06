using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fuel;
    public float accelleration;

    //public Vector2 position;
    private float movementTimerRight;
    private float movementTimerLeft;
    private float movementTimerUp;
    private float movementTimerDown;

    public void MovePlayer()
    {
        //float z = Input.GetAxis("Vertical");
        //float x = Input.GetAxis("Horizontal");  
        
        if (fuel > 0)
        {
            // Key Down
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movementTimerRight += Time.deltaTime;
                //Debug.Log("RightArrow");
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movementTimerLeft += Time.deltaTime;
               //Debug.Log("LeftArrow");
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movementTimerUp += Time.deltaTime;
                //Debug.Log("UpArrow");
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movementTimerDown += Time.deltaTime;
                //Debug.Log("DownArrow");
            }
            
            // Key Released
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movementTimerRight = 0;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movementTimerLeft = 0;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movementTimerUp = 0;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movementTimerDown = 0;
            }
             
        }
        
        // player.velocity.x += player.accell.x * DeltaTime;
        // player.velocity.y += player.accell.y * DeltaTime;
        // player.position.x += player.velocity.x * DeltaTime;
        // player.position.y += player.velocity.y * DeltaTime;
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
