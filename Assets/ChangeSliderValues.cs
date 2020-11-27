using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderValues : MonoBehaviour
{

    public Slider Background_music_slider;
    public Slider SFX_slider;

    // Start is called before the first frame update
    void Start()
    {
        Background_music_slider.value = PlayerPrefs.GetFloat("Background_music_volume");
        SFX_slider.value = PlayerPrefs.GetFloat("SFX_volume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
