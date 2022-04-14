using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class LevelBoundaryController : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;

    public GameObject levelAttributes;
    
    // Start is called before the first frame update
    void Start()
    {
        float gameDimentions = levelAttributes.GetComponent<LevelAttributesController>().levelDimentions;
        Vector3 topVector = new Vector3(0, gameDimentions, 0);
        top.transform.localPosition = topVector;
        Vector3 bottomVector = new Vector3(0, -gameDimentions,0);
        bottom.transform.localPosition = bottomVector;
        Vector3 leftVector = new Vector3(-gameDimentions, 0, 0);
        left.transform.localPosition = leftVector;
        Vector3 rightVector = new Vector3(gameDimentions, 0,0);
        right.transform.localPosition = rightVector;

        //top.= top;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
