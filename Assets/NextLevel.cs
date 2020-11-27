using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{

    public Slider Background_music_slider;
    public Slider SFX_slider;

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Proceed()
    {
        PlayerPrefs.SetFloat("Background_music_volume", Background_music_slider.value);
        PlayerPrefs.SetFloat("SFX_volume", SFX_slider.value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScoreScript.scoreValue = 0;
    }
}
