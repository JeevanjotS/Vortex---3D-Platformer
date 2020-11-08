using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip audioClip;

    public AudioSource audioSource;
    public AudioClip thudClip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }

    void PlayThud()
    {
        audioSource.PlayOneShot(thudClip, 0.5f);
    }
}
