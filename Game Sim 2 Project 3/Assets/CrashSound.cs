using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashSound : MonoBehaviour
{
    public AudioClip clip;

    public AudioSource source;

    public bool playOnce;
    // Start is called before the first frame update
    void Start()
    {
        playOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playOnce)
        {
            if (!source.isPlaying)
            {
                source.Play();
                playOnce = false;
            }
        }
        
        
    }
}
