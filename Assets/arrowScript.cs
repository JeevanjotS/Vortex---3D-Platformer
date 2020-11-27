using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour

{

    public GameObject player;
    public GameObject goal;

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //update arrow pointer
        this.transform.position = player.transform.position + new Vector3(0, 5, 0);
        Vector3 goalDir = goal.transform.position - this.transform.position;
        goalDir = Vector3.Normalize(goalDir);

        float singleStep = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, goalDir, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        //Debug.Log(goalDir);
        //arrow.transform.rotation = Quaternion.Euler(direction.x, direction.y, direction.z);
        //this.transform.eulerAngles = goalDir; 
        
    }
}
