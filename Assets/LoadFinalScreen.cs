using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinalScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<SoundManagerScript>().PlayEndLevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ScoreScript.scoreValue = 0;
        }
    }
}
