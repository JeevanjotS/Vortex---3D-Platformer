using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TractorBeamCollider : MonoBehaviour
{
    public GameObject winText;
    private bool entered = false;
    private float timeElapsed = 0;
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player") && !entered)
        {
            entered = true; 
            FindObjectOfType<SoundManagerScript>().PlayEndLevel();
            winText.SetActive(true);
            //Time.timeScale = 0f;
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
