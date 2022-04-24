using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAttributesController : MonoBehaviour
{
    public float levelDimentions;

    public Vector3 playerStartPosition;

    public bool gameObjectInProperLocation;
    public Vector3 playerStartRotation;

    public Vector3 clawObjectStartPosition;

    public string levelObjectiveText;

    public bool levelCanAdvance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjectInProperLocation)
        {
            levelCanAdvance = true;
        }
        else
        {
            levelCanAdvance = false;
        }
    }
}
