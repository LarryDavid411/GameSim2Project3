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
    public float playerSpeed;
    public Vector2 acceleration;
    public Vector3 velocity;
    private Vector3 previousPosition;
    public Vector3 playerPositionDisplacement;

    private Vector3 rotationVelocity;
    private Vector3 rotationAccelleration;
    private Vector3 previousRotation;

    public GameObject rightJet;
    public GameObject leftJet;
    public GameObject topJet;
    public GameObject bottomJet;
    public GameObject rightRotationJet;
    public GameObject leftRotationJet;

    // CLAW
    public GameObject claw;
    public bool clawFullyOpened;
    public float clawFullyOpenedDistance;
    public bool clawFullyClosed;
    public float clawFullyClosedDistance;
    
    public bool hitWall = false;
    public bool safeLanding = false;
    public float clawSpeed;
  
    
    //public Vector2 position;
    private float movementTimerRight;
    private float movementTimerLeft;
    private float movementTimerUp;
    private float movementTimerDown;
    private float rotateTimerA;
    private float rotateTimerF;
    
    public float movementDuration;
    public float rotateDuration;
    public float safeLandingVelocity;
    
    // LEVEL Controller
    public GameObject levelController;
    public bool gameObjectInProperLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            hitWall = true;
            // if (velocity.x > 1.0 || velocity.y > 1.0)
            // {
            //     hitWall = true;
            // }
            // else
            // {
            //     safeLanding = true;
            // }
        }

        if (other.gameObject.tag == "LandingPad")
        {
            if (Mathf.Abs(velocity.x) > safeLandingVelocity || Mathf.Abs(velocity.y) > safeLandingVelocity)
            {
                hitWall = true;
            }
            else
            {
                safeLanding = true;
                //Debug.Log("Safe Hit");
                //levelController.GetComponent<LevelController>().advanceLevel = true;
            }
        }
    }

    public void ChangeLevel()
    {
        
    }

    public void MovePlayer()
    {
        
        // MOVEMENT
        previousPosition = this.gameObject.transform.position; 
        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
        //Debug.Log(velocity);
        fuel -= Mathf.Abs(acceleration.x * Time.deltaTime) + Mathf.Abs(acceleration.y* Time.deltaTime);

        Vector3 movePlayerPosition = new Vector2();
        movePlayerPosition.x = velocity.x * Time.deltaTime * playerSpeed;
        movePlayerPosition.y = velocity.y * Time.deltaTime * playerSpeed;
        
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
            playerPositionDisplacement = transform.position - previousPosition; 
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
                
                // CLAW OPERATION
                if (Input.GetKey(KeyCode.C))
                {
                    if (claw.transform.localPosition.y >= clawFullyOpenedDistance)
                    {
                        clawFullyOpened = true;
                        Debug.Log("HIT");
                    }
                    else
                    {
                        clawFullyOpened = false;
                    }
                    if (!clawFullyOpened)
                    {
                        claw.transform.position += (Vector3.up * Time.deltaTime * clawSpeed);
                    }
                }
                if (Input.GetKey(KeyCode.V))
                {
                    if (claw.transform.localPosition.y <= clawFullyClosedDistance)
                    {
                        clawFullyClosed = true;
                    }
                    else
                    {
                        clawFullyClosed = false;
                    }
                    if (!clawFullyClosed)
                    {
                        claw.transform.position += (Vector3.down * Time.deltaTime * clawSpeed);
                    }
                }
            }
        }
        else if (hitWall)
        {
            // this.gameObject.transform.position = previousPosition;
           // Debug.Log("Crash");
           levelController.GetComponent<LevelController>().FadeOutAnimation();
        }
        else if (safeLanding)
        {
           // this.gameObject.transform.position = previousPosition;
           // Debug.Log("SafeLanding");
            levelController.GetComponent<LevelController>().FadeOutAnimation();
           // if (gameObjectInProperLocation)
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
