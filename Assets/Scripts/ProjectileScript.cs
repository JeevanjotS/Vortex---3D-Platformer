using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision c) 
    {
        if (c.gameObject.tag != "Enemy" && c.gameObject.tag != "Player") {
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            // gameObject.transform.position = playerPos + new Vector3(0f, 0.875f, 0f);
            gameObject.transform.position = GlobalVar.projPos;
            FindObjectOfType<SoundManagerScript>().PlayEnemyProjectileFall();
            transform.gameObject.SetActive(false);
            // Destroy(gameObject);
        }

        if (c.gameObject.tag == "Enemy") {
            FindObjectOfType<SoundManagerScript>().PlayEnemyDeath();
            Destroy(c.gameObject);
            print("Hit");
        }
    }
}
