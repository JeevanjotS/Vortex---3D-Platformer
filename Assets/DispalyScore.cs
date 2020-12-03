using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispalyScore : MonoBehaviour
{
    // Start is called before the first frame update
    private float score;
    public GameObject gold;
    public GameObject silver;
    public GameObject bronze;
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        gameObject.GetComponent<Text>().text = "Score : " + score;
        print(" Score : " + score);

        if(score >= 180){
            gold.SetActive(true);
        }
        else if(score>=90){
            silver.SetActive(true);
        }
        else{
            bronze.SetActive(true);
        }
    }

    // Update is called once per frame
}
