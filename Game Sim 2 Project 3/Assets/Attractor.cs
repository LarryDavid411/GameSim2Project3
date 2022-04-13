using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rb;
    public float mass;

    public GameObject player;
    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - gameObject.transform.position;
        float distance = direction.magnitude;
        float forceMagnitude = (player.GetComponent<PlayerAttributes>().mass * this.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        Debug.Log(forceMagnitude);

        // Attractor[] attractors = new[] { FindObjectOfType<Attractor>() };
        // foreach (Attractor attractor in attractors) 
        // {
        //     if (attractor != this)
        //     {
        //         Attract(attractor);
        //     }
        // }
    }

    void Attract(Attractor objectToAttract)
    {
        Rigidbody rbToAttract = objectToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;
        
        rbToAttract.AddForce(force);

    }
}
