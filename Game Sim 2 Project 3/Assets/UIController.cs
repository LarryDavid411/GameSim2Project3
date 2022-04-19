using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public bool closedTab;
    private bool rotateOpen;
    private bool rotateClosed;
    public float rotationSpeed;
    public GameObject tabImage;
    public GameObject controlsText;

    public GameObject player;

    public GameObject velocityGagueForward;
    public GameObject accelGagueForward;
    public GameObject velocityGagueReverse;
    public GameObject accelGagueReverse;
    public GameObject velocityGagueLeft;
    public GameObject accelGagueLeft;
    public GameObject velocityGagueRight;
    public GameObject accelGagueRight;

    
    // Start is called before the first frame update
    void Start()
    {
        rotateOpen = false;
        controlsText.SetActive(false);
    }

    public void FuelGauge()
    {
        
    }

    public void UpdateGauges()
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

        FuelGauge();
        UpdateGauges();
    }
}
