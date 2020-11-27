using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Threading;

public class DeathScript : MonoBehaviour
{
    private int currentSceneIndex;
    void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ScoreScript.scoreValue = 0;
        }
        else if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f;
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
            SceneManager.LoadScene("Main Menu");
            ScoreScript.scoreValue = 0;
        }
    }
}
