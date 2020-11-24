using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip audioClip;
    public AudioSource audioSource;

    public static float volume = 1f;

    // public static float volume = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void playSpike()
    {
        audioSource.PlayOneShot(audioClip, volume);
    }

    public void OnValueChanged(float newValue)
    {
        volume = newValue;
    }
    // public static void setVolume(float vol)
    // {
    //     volume = vol;
    // }
}
