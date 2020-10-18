using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
    {
    // Start is called before the first frame update
    
    public AudioClip jump, pickUp, SlimePickUp;
    public AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySoundJump()
    {
        audioSource.PlayOneShot(jump);
    }
    public void PlaySoundPickUp()
    {
        audioSource.PlayOneShot(pickUp);
    }
    public void PlaySoundSlimePickUp()
    {
        audioSource.PlayOneShot(SlimePickUp);
    }
}
