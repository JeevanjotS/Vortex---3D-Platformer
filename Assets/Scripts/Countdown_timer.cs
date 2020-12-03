using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown_timer : MonoBehaviour
{
    // Start is called before the first frame update
    public static float currtime;
    public float timeStart;
    public Text textBox;
    public Color criticalTimerColor;
    public Animator anim;
    
    public GameObject deathText;
    void Start()
    {
        currtime = timeStart;
        anim = GetComponent<Animator>();
    }

    public void addToTimer(float value){
        timeStart+=value;
        currtime+=value;
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
            currtime -= Time.deltaTime;
            textBox.text = "Time : " + timeStart.ToString("F2");
        }
    }

    public void returnTime()
    {

    }
}
