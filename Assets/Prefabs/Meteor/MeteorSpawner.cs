using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject meteor_prefab;
    private GameObject meteor;
    private Vector3 position;
    
    private float velocity_x;
    private float velocity_y;
    private float velocity_z;
    
    private float velocity_magnitude;
    public int numberOfStartMeteors;
    public float updateMeteorProbability;
    public float range;
    public float y_range;
    void Start()
    {
        for(int i=0; i<numberOfStartMeteors; i++){
            position = new Vector3(Random.Range(-range, range), Random.Range(-range, y_range), Random.Range(-range, range));
            velocity_x = Random.Range(-10.0f, 10.0f);
            velocity_y = 0;
            velocity_z = Random.Range(-10.0f, 10.0f);
            velocity_magnitude = Mathf.Pow(Mathf.Pow( velocity_x, 2) + Mathf.Pow( velocity_y, 2) + Mathf.Pow( velocity_z, 2),0.5F);
            velocity_x = velocity_x * 50 / velocity_magnitude;
            velocity_y = velocity_y * 50 / velocity_magnitude;
            velocity_z = velocity_z * 50 / velocity_magnitude;
            meteor = Instantiate(meteor_prefab, position, Quaternion.identity);
            meteor.gameObject.GetComponent<MeteorVelocity>().speed = new Vector3(velocity_x, velocity_y, velocity_z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1.0f) < updateMeteorProbability) 
        {
            position = new Vector3(Random.Range(-range, range), Random.Range(-range, y_range), Random.Range(-range, range));
            velocity_x = Random.Range(-10.0f, 10.0f);
            velocity_y = 0;
            velocity_z = Random.Range(-10.0f, 10.0f);
            velocity_magnitude = Mathf.Pow(Mathf.Pow( velocity_x, 2) + Mathf.Pow( velocity_y, 2) + Mathf.Pow( velocity_z, 2),0.5F);
            velocity_x = velocity_x * 50 / velocity_magnitude;
            velocity_y = velocity_y * 50 / velocity_magnitude;
            velocity_z = velocity_z * 50 / velocity_magnitude;
            meteor = Instantiate(meteor_prefab, position, Quaternion.identity);
            meteor.gameObject.GetComponent<MeteorVelocity>().speed = new Vector3(velocity_x, velocity_y, velocity_z);
        }
    }
}
