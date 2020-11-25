using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown_timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeStart;
    public Text textBox;
    public Color criticalTimerColor;
    public Animator anim;
    
    public GameObject deathText;
    void Start()
    {
        anim = GetComponent<Animator>();
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
            if (timeStart <= 30)
            {
                textBox.color = criticalTimerColor;
                anim.SetBool("IsLowTime", true);
            }
            else
            {
                anim.SetBool("IsLowTime", false);
            }
            timeStart -=Time.deltaTime;
            textBox.text = "Time : " + timeStart.ToString("F2");
        }
    }
}
