using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    public int currentLevel;

    public GameObject player;
    public GameObject[] levels = new GameObject[5];

    public float levelMovementScale;
    public GameObject levelSetController;
    public GameObject clawObject;
    public GameObject playerClaw;
    public GameObject clawGrabber;
    public Text levelText;
    public GameObject clawInProperPosition;

    public GameObject crashSound;
    public bool advanceLevel;

    public Animator animator;

    public GameObject safeLandingText;
    public GameObject youCrashedText;
    public GameObject pressEnterNextLevelText;
    public GameObject pressEnterPreviousLevel;
    public GameObject objectNotInProperLocationText;

    public float pressEnterDisplayTimer;
    public bool pressEnterAllowed;
    public bool fadingOut;

   // public GameObject levelAttributesController;
    
    // Start is called before the first frame update
    public void RestartEverything()
    {
        //Debug.Log(levels.Length);
        player.GetComponent<PlayerController>().acceleration = Vector2.zero;
        player.GetComponent<PlayerController>().velocity = Vector3.zero;
        player.GetComponent<PlayerController>().rotationAccelleration = Vector3.zero;
        player.GetComponent<PlayerController>().rotationVelocity = Vector3.zero;
        player.GetComponent<PlayerController>().fuel = 100;
        player.transform.position =
            levels[currentLevel - 1].GetComponent<LevelAttributesController>().playerStartPosition;
        player.transform.eulerAngles = levels[currentLevel - 1].GetComponent<LevelAttributesController>().playerStartRotation;
        clawObject.GetComponent<ClawObjectController>().MoveOutOfPlayerParent();
        clawObject.transform.position =
            levels[currentLevel - 1].GetComponent<LevelAttributesController>().clawObjectStartPosition;
        levelText.text =  levels[currentLevel - 1].GetComponent<LevelAttributesController>().levelObjectiveText;
        playerClaw.transform.position = new Vector3(0, 0.2f, 0);
        clawGrabber.GetComponent<ClawGrabController>().objectGrabbed = false;
        clawGrabber.GetComponent<ClawGrabController>().cantGrabObjectTimer = 0;
        clawGrabber.GetComponent<ClawGrabController>().startCantGrabObjectTimer = false;
        crashSound.gameObject.SetActive(false);
        crashSound.GetComponent<CrashSound>().playOnce = true;
        //clawInProperPosition.SetActive(false);
    }
    void Start()
    {
        RestartEverything();
        //levelText.text =  levels[currentLevel - 1].GetComponent<LevelAttributesController>().levelObjectiveText;
        // cameraPositionForLevel = new Vector4[10];
        // float levelPositionForY = 0;
        // for (int i = 0; i < 10; i++)
        // {
        //     cameraPositionForLevel[i] = new Vector4(0, levelPositionForY, -10, -1);
        //     levelPositionForY += 200;
        // }
    }

    
    public void FadeOutAnimation()
    {
        if (!fadingOut)
        {
            pressEnterDisplayTimer += Time.deltaTime;
            if (pressEnterDisplayTimer > 1.0)
            {
                pressEnterAllowed = true;
            }
        
            if (player.GetComponent<PlayerController>().safeLanding)
            {
                if (levels[currentLevel - 1].GetComponent<LevelAttributesController>().gameObjectInProperLocation)
                {
                    safeLandingText.SetActive(true);
                    if (pressEnterAllowed)
                    {
                        pressEnterNextLevelText.SetActive(true);
                    } 
                }
                else
                {
                    objectNotInProperLocationText.SetActive(true);
                    if (pressEnterAllowed)
                    {
                        pressEnterPreviousLevel.SetActive(true);
                    } 
                }
            }
       
            if (player.GetComponent<PlayerController>().hitWall)
            {
                youCrashedText.SetActive(true);
                if (pressEnterAllowed)
                {
                    pressEnterPreviousLevel.SetActive(true);
                }
            }
        }

       if (Input.GetKey(KeyCode.Return) && pressEnterAllowed)
        {
            animator.ResetTrigger("FadeIn");
            animator.SetTrigger("FadeOut");
            safeLandingText.SetActive(false);
            youCrashedText.SetActive(false);
            pressEnterPreviousLevel.SetActive(false);
            pressEnterNextLevelText.SetActive(false);
            objectNotInProperLocationText.SetActive(false);
            fadingOut = true;
        }
    }

    public void ChangeLevel()
    {
        if (player.GetComponent<PlayerController>().safeLanding)
        {
            if (levels[currentLevel - 1].GetComponent<LevelAttributesController>().gameObjectInProperLocation)
            {
                
                levels[currentLevel-1].SetActive(false);
                currentLevel++;
                if (currentLevel >= levels.Length)
                {
                    SceneManager.LoadScene("Game Over");
                }
                levels[currentLevel-1].SetActive(true);
            }
            else
            {
                
            }
        }
        else if (player.GetComponent<PlayerController>().hitWall)
        {
           // player.GetComponent<PlayerController>().velocity = Vector3.zero;
           // player.GetComponent<PlayerController>().acceleration = Vector2.zero;
            //levelSetController.SetActive(true);
            //levelSetController.SetActive(false);
            
            // SET ACCEL TO ZERO.
           
        }
        RestartEverything();
        // player.GetComponent<PlayerController>().acceleration = Vector2.zero;
        // player.GetComponent<PlayerController>().velocity = Vector3.zero;
        // player.GetComponent<PlayerController>().rotationAccelleration = Vector3.zero;
        // player.GetComponent<PlayerController>().rotationVelocity = Vector3.zero;
        // player.GetComponent<PlayerController>().fuel = 100;
        // player.transform.position =
        //     levels[currentLevel - 1].GetComponent<LevelAttributesController>().playerStartPosition;
        // player.transform.eulerAngles = levels[currentLevel - 1].GetComponent<LevelAttributesController>().playerStartRotation;
        // clawObject.GetComponent<ClawObjectController>().MoveOutOfPlayerParent();
        // clawObject.transform.position =
        //     levels[currentLevel - 1].GetComponent<LevelAttributesController>().clawObjectStartPosition;
        // levelText.text =  levels[currentLevel - 1].GetComponent<LevelAttributesController>().levelObjectiveText;
        // playerClaw.transform.position = new Vector3(0, 0.2f, 0);
        // clawGrabber.GetComponent<ClawGrabController>().objectGrabbed = false;
        // clawGrabber.GetComponent<ClawGrabController>().cantGrabObjectTimer = 0;
        // clawGrabber.GetComponent<ClawGrabController>().startCantGrabObjectTimer = false;
        
       // clawObject.tran
        
        // levels[currentLevel-1].SetActive(false);
        // currentLevel++;
        // levels[currentLevel-1].SetActive(true);
        //advanceLevel = false;
        //Debug.Log(currentLevel);
        animator.ResetTrigger("FadeOut");
        animator.SetTrigger("FadeIn");
        player.GetComponent<PlayerController>().safeLanding = false;
        player.GetComponent<PlayerController>().hitWall = false;
        fadingOut = false;
        pressEnterDisplayTimer = 0;
        pressEnterAllowed = false;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
        
        
        // Vector3 playerMovement = player.GetComponent<PlayerController>().playerPositionDisplacement;
       // levels[currentLevel].transform.position += playerMovement / levelMovementScale;


        //camera.transform.position = cameraPositionForLevel[currentLevel];
    }
}
