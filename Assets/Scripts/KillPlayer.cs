using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject deathText;


    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
        {
            FindObjectOfType<SoundManagerScript>().PlayFalling();
            deathText.SetActive(true);
        }

        if(c.gameObject.name== "Projectile"){
            c.transform.position = GlobalVar.projPos;
            c.gameObject.SetActive(false);
        }
    }
}
