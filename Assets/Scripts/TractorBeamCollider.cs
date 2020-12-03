using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TractorBeamCollider : MonoBehaviour
{
    public GameObject winText;
    private bool entered = false;
    private float timeElapsed = 0;

    private float displayScore;
    public GameObject scoreText;

    public GameObject gold;
    public GameObject silver;
    public GameObject bronze;
    // public Countdown_timer ct;
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player") && !entered)
        {
            entered = true; 
            FindObjectOfType<SoundManagerScript>().PlayEndLevel();
            // winText.SetActive(true);
            //Time.timeScale = 0f;
            // ct = GetComponent<Countdown_timer>();
            displayScore = (int) Countdown_timer.currtime + ScoreScript.scoreValue;
            scoreText.GetComponent<TextMeshProUGUI>().text = "Score : " + displayScore;
            if (displayScore >= 300) {
                gold.SetActive(true);
            }
            else if (displayScore >= 150){
                silver.SetActive(true);
            } 
            else{
                bronze.SetActive(true);
            }
            winText.SetActive(true);
        }
    }

    void Update()
    {
        // if (entered)
        // {
        //     timeElapsed+=Time.deltaTime;
        //     if (timeElapsed>=2){
        //         print(Time.timeScale = 0f);
        //     }
        // }
    }

}
