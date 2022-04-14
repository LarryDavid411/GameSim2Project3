using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{

    public GameObject star;
    private float generationTimer;
    public GameObject playerObject;

    public Transform starParent;
    //public GameObject camera;

    private int starCount;
    private Vector4[] starArray = new Vector4[100000]; 

    public void GenerateStars()
    {
        Vector3 randomStarPosition = new Vector3(0,0,0 );
        float randomNumberOfStarsInRow = Random.Range(10, 100);
        float randomNumberOfStarsInColumn = Random.Range(10, 1000);
        for (int i = 0; i < randomNumberOfStarsInRow * randomNumberOfStarsInColumn; i++)
        {
            randomStarPosition.x = Random.Range(-1230f, 1230f);
            randomStarPosition.y = Random.Range(-1230f, 1230f);
            starArray[starCount] = randomStarPosition;
            GameObject starCreated = Instantiate(star, starParent);
            starCreated.GetComponent<StarMover>().transform.position = randomStarPosition;
            float randomScale = Random.Range(1, 20);
            starCreated.GetComponent<StarMover>().transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            starCount++;
        }
    }

    public void MoveStars(GameObject player)
    {
        for (int i = 0; i < starCount; i++)
        {
           // starArray
        }
    }
    
    public void MoveAndGenerateStars()
    {
        if (generationTimer > 1.5)
        {
            for (int i = 0; i < 4; i++)    
            {
                GameObject starCreated = Instantiate(star, starParent);
                float randomDirection = Random.Range(-0.5f, -0.1f);
                starCreated.GetComponent<StarMover>().starVelocity = new Vector3(randomDirection,randomDirection, 0);
                float randomStartPosition = Random.Range(0, 300);
                starCreated.GetComponent<StarMover>().transform.position = new Vector3(150, randomStartPosition, 0);
                float randomScale = Random.Range(1, 20);
                starCreated.GetComponent<StarMover>().transform.localScale = new Vector3(randomScale, randomScale, randomScale);
                starCreated.GetComponent<StarMover>().destroy = true;
                generationTimer = 0;
            }
        }
        generationTimer += Time.deltaTime;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateStars();
    }

    // Update is called once per frame
    void Update()
    {
        MoveStars(playerObject);
    }
}
