using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public float fuel;
    public GameObject fuelBar;
    public float playerSpeed;
    public float rotationSpeed;
    public Vector2 acceleration;
    public Vector3 velocity;
    private Vector3 previousPosition;
    public Vector3 playerPositionDisplacement;
    
    public Vector3 rotationVelocity;
    public Vector3 rotationAccelleration;
    private Vector3 previousRotation;
    

    /*
    public GameObject rightJet;
    public GameObject leftJet;
    public GameObject topJet;
    public GameObject bottomJet;
    public GameObject rightRotationJet;
    public GameObject leftRotationJet;
    */
    
    public ParticleSystem bottomFlame;
    public ParticleSystem topFlame;
    public ParticleSystem rightFlame;
    public ParticleSystem leftFlame;
    public ParticleSystem rightRotationFlame;
    public ParticleSystem leftRotationFlame;

    public ParticleSystem[] allFlames = new ParticleSystem[6];

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

    public void ResetFlames()
    {
        for (int i = 0; i < 6; i++)
        {
            allFlames[i].gameObject.SetActive(false);
        }
    }

    public void ResetAccel()
    {
        acceleration = Vector2.zero;
        rotationAccelleration = Vector3.zero;
    }
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

    public void SetFuel(float fuelGauge)
    {
        fuelBar.GetComponent<Slider>().value = (fuel / 100);
    }

    public void MovePlayer(bool gamePaused)
    {
        
        // MOVEMENT
        previousPosition = this.gameObject.transform.position; 
        velocity.x += acceleration.x * Time.deltaTime ;
        velocity.y += acceleration.y * Time.deltaTime ;
        //Debug.Log(velocity);
        fuel -= Mathf.Abs(acceleration.x * Time.deltaTime) + Mathf.Abs(acceleration.y* Time.deltaTime);
        SetFuel(fuel);
        Vector3 movePlayerPosition = new Vector2();
        movePlayerPosition.x = velocity.x * Time.deltaTime * playerSpeed;
        movePlayerPosition.y = velocity.y * Time.deltaTime * playerSpeed;
        
        // ROTATION
        previousRotation = this.gameObject.transform.eulerAngles;
        rotationVelocity.z += rotationAccelleration.z * Time.deltaTime;
        Vector3 rotatePlayerPosition = new Vector3();
        rotatePlayerPosition.z = rotationVelocity.z * Time.deltaTime * rotationSpeed;

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
                    //leftJet.SetActive(true);
                    leftFlame.gameObject.SetActive(true);
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    movementTimerLeft += Time.deltaTime;
                    float time = movementTimerLeft / movementDuration;
                    acceleration.x = -Mathf.Lerp(0f, 20f, time);
                    //rightJet.SetActive(true);
                    rightFlame.gameObject.SetActive(true);
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    movementTimerUp += Time.deltaTime;
                    float time = movementTimerUp / movementDuration;
                    acceleration.y = Mathf.Lerp(0f, 20f, time);
                    //bottomJet.SetActive(true);
                    bottomFlame.gameObject.SetActive(true);
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    movementTimerDown += Time.deltaTime;
                    float time = movementTimerDown / movementDuration;
                    acceleration.y = -Mathf.Lerp(0f, 20f, time);
                   // topJet.SetActive(true);
                    topFlame.gameObject.SetActive(true);
                }
                
                
                if (Input.GetKey(KeyCode.A))
                {
                    rotateTimerA += Time.deltaTime;
                    float time = rotateTimerA / rotateDuration;
                    rotationAccelleration.z = -Mathf.Lerp(0, 10, time);
                   //  leftRotationJet.SetActive(true);
                    leftRotationFlame.gameObject.SetActive(true);

                }
                if (Input.GetKey(KeyCode.F))
                {
                    rotateTimerF += Time.deltaTime;
                    float time = rotateTimerF / rotateDuration;
                    rotationAccelleration.z = Mathf.Lerp(0, 5, time);
                    //  rightRotationJet.SetActive(true);
                    rightRotationFlame.gameObject.SetActive(true);
                }

                // Key Released
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    acceleration.x = 0;
                    movementTimerRight = 0;
                   // leftJet.SetActive(false);
                   leftFlame.gameObject.SetActive(false);
                }

                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    acceleration.x = 0;
                    movementTimerLeft = 0;
                   // rightJet.SetActive(false);
                   rightFlame.gameObject.SetActive(false);
                }

                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    acceleration.y = 0;
                    movementTimerUp = 0;
                    //bottomJet.SetActive(false);
                    bottomFlame.gameObject.SetActive(false);
                }

                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    acceleration.y = 0;
                    movementTimerDown = 0;
                    //topJet.SetActive(false);
                    topFlame.gameObject.SetActive(false);
                   
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    rotationAccelleration.z = 0;    
                    rotateTimerA = 0;
                    //leftRotationJet.SetActive(false);
                    leftRotationFlame.gameObject.SetActive(false);
                }
                if (Input.GetKeyUp(KeyCode.F))
                {
                    rotationAccelleration.z = 0;
                    rotateTimerF = 0;
                    //rightRotationJet.SetActive(false);
                    rightRotationFlame.gameObject.SetActive(false);
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
                        claw.transform.localPosition += (Vector3.up * Time.deltaTime * clawSpeed);
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
                        claw.transform.localPosition += (Vector3.down * Time.deltaTime * clawSpeed);
                    }
                }
            }
            else
            {
                ResetFlames();
                rotationAccelleration = Vector3.zero;
                acceleration = Vector2.zero;
            }
        }
        else if (hitWall)
        {
            // this.gameObject.transform.position = previousPosition;
           // Debug.Log("Crash");
           levelController.GetComponent<LevelController>().FadeOutAnimation();
           ResetFlames();
        }
        else if (safeLanding)
        {
           // this.gameObject.transform.position = previousPosition;
           // Debug.Log("SafeLanding");
            levelController.GetComponent<LevelController>().FadeOutAnimation();
           // if (gameObjectInProperLocation)
           ResetFlames();
        }
        //Debug.Log("Current Velocity: " + velocity);
    }
}
