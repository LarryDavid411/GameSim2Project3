using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public AudioClip clip;

    public AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
        
    }
}
