using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public bool closedTab;
    private bool rotateOpen;
    private bool rotateClosed;
    public float rotationSpeed;
    public GameObject tabImage;
    public GameObject controlsText;

    public GameObject player;
   // public GameObject 

    public GameObject velocityGagueForward;
    public GameObject accelGagueForward;
    public GameObject velocityGagueReverse;
    public GameObject accelGagueReverse;
    public GameObject velocityGagueLeft;
    public GameObject accelGagueLeft;
    public GameObject velocityGagueRight;
    public GameObject accelGagueRight;
    public GameObject rotationGaugeRightAccel;
    public GameObject rotationGaugeRightVelocity;
    public GameObject rotationGaugeLeftAccel;
    public GameObject rotationGaugeLeftVelocity;

    
    // Start is called before the first frame update
    void Start()
    {
        rotateOpen = false;
        controlsText.SetActive(false);
    }

    public void FuelGauge()
    {
        // Forward & Reverse Velocity
        if (player.gameObject.GetComponent<PlayerController>().velocity.y > 0)
        {
            velocityGagueForward.gameObject.GetComponent<Text>().text =
                player.gameObject.GetComponent<PlayerController>().velocity.y.ToString();
        }
        else
        {
            velocityGagueForward.gameObject.GetComponent<Text>().text = "0.0";
        }
        
        if (player.gameObject.GetComponent<PlayerController>().velocity.y < 0)
        {
            float reverseVelocityFloat = -player.gameObject.GetComponent<PlayerController>().velocity.y;
            string reverseVelocityString = reverseVelocityFloat.ToString();

            velocityGagueReverse.gameObject.GetComponent<Text>().text = reverseVelocityString;
        }
        else
        {
            velocityGagueReverse.gameObject.GetComponent<Text>().text = "0.0";
        }
        
        // Left & Right Velocity
        if (player.gameObject.GetComponent<PlayerController>().velocity.x > 0)
        {
            velocityGagueRight.gameObject.GetComponent<Text>().text =
                player.gameObject.GetComponent<PlayerController>().velocity.x.ToString();
        }
        else
        {
            velocityGagueRight.gameObject.GetComponent<Text>().text = "0.0";
        }
        
        if (player.gameObject.GetComponent<PlayerController>().velocity.x < 0)
        {
            float leftVelocityFloat = -player.gameObject.GetComponent<PlayerController>().velocity.x;
            string leftVelocityString = leftVelocityFloat.ToString();

            velocityGagueLeft.gameObject.GetComponent<Text>().text = leftVelocityString;
        }
        else
        {
            velocityGagueLeft.gameObject.GetComponent<Text>().text = "0.0";
        }
        
        // Forward & Reverse Acceleration
        if (player.gameObject.GetComponent<PlayerController>().acceleration.y > 0)
        {
            accelGagueForward.gameObject.GetComponent<Text>().text =
                player.gameObject.GetComponent<PlayerController>().acceleration.y.ToString();
        }
        else
        {
            accelGagueForward.gameObject.GetComponent<Text>().text = "0.0";
        }
        
        if (player.gameObject.GetComponent<PlayerController>().acceleration.y < 0)
        {
            float forwardAccelerationFloat = -player.gameObject.GetComponent<PlayerController>().acceleration.y;
            string forwardAccelerationString = forwardAccelerationFloat.ToString();

            accelGagueReverse.gameObject.GetComponent<Text>().text = forwardAccelerationString;
        }
        else
        {
            accelGagueReverse.gameObject.GetComponent<Text>().text = "0.0";
        }
        
        // Left & Right Accelleration
        if (player.gameObject.GetComponent<PlayerController>().acceleration.x > 0)
        {
            accelGagueRight.gameObject.GetComponent<Text>().text =
                player.gameObject.GetComponent<PlayerController>().acceleration.x.ToString();
        }
        else
        {
            accelGagueRight.gameObject.GetComponent<Text>().text = "0.0";
        }
        
        if (player.gameObject.GetComponent<PlayerController>().acceleration.x < 0)
        {
            float leftAccelerationFloat = -player.gameObject.GetComponent<PlayerController>().acceleration.x;
            string leftAccelerationString = leftAccelerationFloat.ToString();

            accelGagueLeft.gameObject.GetComponent<Text>().text = leftAccelerationString;
        }
        else
        {
            accelGagueLeft.gameObject.GetComponent<Text>().text = "0.0";
        }
        
        // Rotation Acceleration
        if (player.gameObject.GetComponent<PlayerController>().rotationAccelleration.z > 0)
        {
            rotationGaugeRightAccel.gameObject.GetComponent<Text>().text = player.gameObject
                .GetComponent<PlayerController>().rotationAccelleration.z.ToString();
        }
        else
        {
            rotationGaugeRightAccel.gameObject.GetComponent<Text>().text = "0.0";
        }
        if (player.gameObject.GetComponent<PlayerController>().rotationAccelleration.z < 0)
        {
            float leftRotationAccelerationFloat = -player.gameObject
                .GetComponent<PlayerController>().rotationAccelleration.z;
            string leftRotationAccelerationString = leftRotationAccelerationFloat.ToString();

            rotationGaugeLeftAccel.gameObject.GetComponent<Text>().text = leftRotationAccelerationString;
        }
        else
        {
            rotationGaugeLeftAccel.gameObject.GetComponent<Text>().text = "0.0";
        }
        
        // Rotation Velocity
        if (player.gameObject.GetComponent<PlayerController>().rotationVelocity.z > 0)
        {
            rotationGaugeRightVelocity.gameObject.GetComponent<Text>().text =
                player.gameObject.GetComponent<PlayerController>().rotationVelocity.z.ToString();
        }
        else
        {
            rotationGaugeRightVelocity.gameObject.GetComponent<Text>().text = "0.0";
        }

        if (player.gameObject.GetComponent<PlayerController>().rotationVelocity.z < 0)
        {
            float leftRotationVelocityFloat =
                -player.gameObject.GetComponent<PlayerController>().rotationVelocity.z;
            string leftRotationVelocityString = leftRotationVelocityFloat.ToString();

            rotationGaugeLeftVelocity.gameObject.GetComponent<Text>().text = leftRotationVelocityString;
        }
        else
        {
            rotationGaugeLeftVelocity.gameObject.GetComponent<Text>().text = "0.0";
        }
    }
    


    public void UpdateMovementGauges()
    {
        
    }
    public void RotateTabOpen()
    {

        if (tabImage.GetComponent<RectTransform>().eulerAngles.z >= 180)
        {
            tabImage.transform.eulerAngles += (Vector3.back * Time.deltaTime * rotationSpeed);
        }
        else
        {
            Vector3 setTab = new Vector3(0, 0, 180);
            tabImage.GetComponent<RectTransform>().eulerAngles = setTab;
            rotateOpen = false;
            closedTab = false;
            controlsText.SetActive(true);
        }
    }

    public void RotateTabClosed()
    {
        if (tabImage.GetComponent<RectTransform>().eulerAngles.z <= 270)
        {
            tabImage.transform.eulerAngles += (Vector3.forward * Time.deltaTime * rotationSpeed);
            controlsText.SetActive(false);
        }
        else
        {
            Vector3 setTab = new Vector3(0, 0, 270);
            tabImage.GetComponent<RectTransform>().eulerAngles = setTab;
            rotateClosed = false;
            closedTab = true;
        }

    }

    public void UpdateClawObjectInPositionUI()
    {
       // if ()
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(tabImage.GetComponent<RectTransform>().eulerAngles.z);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (closedTab)
            {
                rotateOpen = true;
            }
            else
            {
                rotateClosed = true;
            }
        }

        if (rotateOpen)
        {
            RotateTabOpen();
        }

        if (rotateClosed)
        {
            RotateTabClosed();
        }

        UpdateClawObjectInPositionUI();
        FuelGauge();
        UpdateMovementGauges();
    }
}
