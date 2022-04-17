using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public int currentLevel;

    public GameObject player;
    public GameObject[] levels = new GameObject[2];

    public float levelMovementScale;
    public GameObject levelSetController;

    public bool advanceLevel;

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log("Top is :" + advanceLevel);

        if (Input.GetKey(KeyCode.Return))
        {
            animator.ResetTrigger("FadeIn");
            animator.SetTrigger("FadeOut");
            //animator.
        }
        
        Debug.Log("Bottom is :" + advanceLevel);
    }


    public void ChangeLevel()
    {
        if (player.GetComponent<PlayerController>().safeLanding)
        {
            levels[currentLevel-1].SetActive(false);
            currentLevel++;
            levels[currentLevel-1].SetActive(true);
        }
        else if (player.GetComponent<PlayerController>().hitWall)
        {
            levelSetController.SetActive(true);
            levelSetController.SetActive(false);
        }
        // levels[currentLevel-1].SetActive(false);
        // currentLevel++;
        // levels[currentLevel-1].SetActive(true);
        //advanceLevel = false;
        //Debug.Log(currentLevel);
        animator.ResetTrigger("FadeOut");
        animator.SetTrigger("FadeIn");
        player.GetComponent<PlayerController>().safeLanding = false;
        player.GetComponent<PlayerController>().hitWall = false;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
        
        
        // Vector3 playerMovement = player.GetComponent<PlayerController>().playerPositionDisplacement;
       // levels[currentLevel].transform.position += playerMovement / levelMovementScale;


        //camera.transform.position = cameraPositionForLevel[currentLevel];
    }
}
