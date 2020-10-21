using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
    {
    // Start is called before the first frame update
    
    public AudioClip jump, pickUp, slimePickUp, fire, enemy_death, projectlie_fall;
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
        audioSource.PlayOneShot(slimePickUp);
    }
    public void PlaySoundFire()
    {
        audioSource.PlayOneShot(fire);
    }
    public void PlayEnemyDeath()
    {
        audioSource.PlayOneShot(enemy_death);
    }
    public void PlayEnemyProjectileFall()
    {
        audioSource.PlayOneShot(projectlie_fall);
    }
}
