using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject deathText;

    void Start()
    {
        deathText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        FindObjectOfType<SoundManagerScript>().PlayFalling();
        deathText.SetActive(true);
    }
}
