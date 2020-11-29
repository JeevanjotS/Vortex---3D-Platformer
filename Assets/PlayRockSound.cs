using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRockSound : MonoBehaviour
{
    public AudioClip audioClip;
    public static float volume = 1f;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            audioSource.PlayOneShot(audioClip, volume);
        }
    }

}
