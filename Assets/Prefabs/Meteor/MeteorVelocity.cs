using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime ); 
    }

    private void OnCollisionEnter(Collision c)
    {
        print("Entered Meteors");
        this.gameObject.SetActive(false);
    }
}
