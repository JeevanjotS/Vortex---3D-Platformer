using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume( float volume)
    {
        UnityEngine.Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
