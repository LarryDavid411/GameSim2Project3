using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{

    public GameObject star;
    private float generationTimer;
    
    public void MoveAndGenerateStars()
    {

        
        if (generationTimer > 0.2)
        {
            for (int i = 0; i < 10; i++)    
            {
                GameObject starCreated = Instantiate(star);
                float randomDirection = Random.Range(-0.2f, -0.0001f);
                starCreated.GetComponent<StarMover>().starVelocity = new Vector3(randomDirection,randomDirection, 0);
                float randomStartPosition = Random.Range(-10, 300);
                starCreated.GetComponent<StarMover>().transform.position = new Vector3(200, randomStartPosition, 0);
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
