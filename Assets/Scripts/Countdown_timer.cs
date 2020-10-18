using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown_timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeStart;
    public Text textBox;
    
    public GameObject deathText;
    void Start()
    {
        
    }

    public void addToTimer(float value){
        timeStart+=value;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart<=0)
        {
            deathText.SetActive(true);
            Time.timeScale = 0f;
        }
        else{
            timeStart-=Time.deltaTime;
            textBox.text = "Time : " + timeStart.ToString("F2");
        }
    }
}
