using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
    {
    // Start is called before the first frame update
    
    public AudioClip jump, pickUp, slimePickUp, fire, enemy_death, projectlie_fall, end_level, falling, thud;
    public AudioSource audioSource;
    public float falling_volume, slimePickUp_volume, pickUp_volume;
    
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
        audioSource.PlayOneShot(pickUp, pickUp_volume);
    }
    public void PlaySoundSlimePickUp()
    {
        audioSource.PlayOneShot(slimePickUp, slimePickUp_volume);
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

    public void PlayEndLevel()
    {
        audioSource.PlayOneShot(end_level);
    }

    public void PlayFalling()
    {
        audioSource.PlayOneShot(falling,falling_volume);
    }
    public void PlayThud()
    {
        audioSource.PlayOneShot(thud);
    }
}
