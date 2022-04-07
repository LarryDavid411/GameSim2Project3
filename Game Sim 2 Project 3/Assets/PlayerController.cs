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
    private Vector2 previousPosition;

    private Vector3 rotationVelocity;
    private Vector3 rotationAccelleration;
    private Vector3 previousRotation;

    public GameObject rightJet;
    public GameObject leftJet;
    public GameObject topJet;
    public GameObject bottomJet;
    public GameObject rightRotationJet;
    public GameObject leftRotationJet;
    
    public bool hitWall = false;
    public bool safeLanding = false;
    
    //public Vector2 position;
    private float movementTimerRight;
    private float movementTimerLeft;
    private float movementTimerUp;
    private float movementTimerDown;
    private float rotateTimerA;
    private float rotateTimerF;
    
    public float movementDuration;
    public float rotateDuration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (velocity.x > 1.0 || velocity.y > 1.0)
            {
                hitWall = true;
            }
            else
            {
                safeLanding = true;
            }
        }
    }

    public void MovePlayer()
    {
        // MOVEMENT
        previousPosition = this.gameObject.transform.position; 
        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
        Vector3 movePlayerPosition = new Vector2();
        movePlayerPosition.x = velocity.x * Time.deltaTime;
        movePlayerPosition.y = velocity.y * Time.deltaTime;
        
        // ROTATION
        previousRotation = this.gameObject.transform.eulerAngles;
        rotationVelocity.z += rotationAccelleration.z * Time.deltaTime;
        Vector3 rotatePlayerPosition = new Vector3();
        rotatePlayerPosition.z = rotationVelocity.z * Time.deltaTime;
        
        
        if (!hitWall && !safeLanding)
        {
            movePlayerPosition = transform.worldToLocalMatrix.inverse *(movePlayerPosition);
            this.gameObject.transform.localPosition += movePlayerPosition;
            this.gameObject.transform.Rotate(rotatePlayerPosition);
            if (fuel > 0)
            {
                // Key Down
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    movementTimerRight += Time.deltaTime;
                    float time = movementTimerRight / movementDuration;
                    acceleration.x = Mathf.Lerp(0f, 20f, time);
                    leftJet.SetActive(true);
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    movementTimerLeft += Time.deltaTime;
                    float time = movementTimerLeft / movementDuration;
                    acceleration.x = -Mathf.Lerp(0f, 20f, time);
                    rightJet.SetActive(true);
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    movementTimerUp += Time.deltaTime;
                    float time = movementTimerUp / movementDuration;
                    acceleration.y = Mathf.Lerp(0f, 20f, time);
                    bottomJet.SetActive(true);
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    movementTimerDown += Time.deltaTime;
                    float time = movementTimerDown / movementDuration;
                    acceleration.y = -Mathf.Lerp(0f, 20f, time);
                    topJet.SetActive(true);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rotateTimerA += Time.deltaTime;
                    float time = rotateTimerA / rotateDuration;
                    rotationAccelleration.z = -Mathf.Lerp(0, 10, time);
                    leftRotationJet.SetActive(true);

                }
                if (Input.GetKey(KeyCode.F))
                {
                    rotateTimerF += Time.deltaTime;
                    float time = rotateTimerF / rotateDuration;
                    rotationAccelleration.z = Mathf.Lerp(0, 5, time);
                    rightRotationJet.SetActive(true);
                }

                // Key Released
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    acceleration.x = 0;
                    movementTimerRight = 0;
                    leftJet.SetActive(false);
                }

                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    acceleration.x = 0;
                    movementTimerLeft = 0;
                    rightJet.SetActive(false);
                }

                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    acceleration.y = 0;
                    movementTimerUp = 0;
                    bottomJet.SetActive(false);
                }

                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    acceleration.y = 0;
                    movementTimerDown = 0;
                    topJet.SetActive(false);
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    rotationAccelleration.z = 0;
                    rotateTimerA = 0;
                    leftRotationJet.SetActive(false);
                }
                if (Input.GetKeyUp(KeyCode.F))
                {
                    rotationAccelleration.z = 0;
                    rotateTimerF = 0;
                    rightRotationJet.SetActive(false);
                }
            }
        }
        else if (hitWall)
        {
            this.gameObject.transform.position = previousPosition;
            Debug.Log("Crash");
        }
        else if (safeLanding)
        {
            this.gameObject.transform.position = previousPosition;
            Debug.Log("SafeLanding");
        }
        //Debug.Log("Current Velocity: " + velocity);
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
