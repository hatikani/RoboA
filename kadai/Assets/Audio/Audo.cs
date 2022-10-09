using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audo : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip Sound01;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(Sound01);
        }
    }
}
