using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.EventSystems;

public class CollectableSlime : MonoBehaviour
{

    // void Start()
    // {
    //     gameObject.transform.parent.gameObject
    // }

    void OnTriggerEnter(Collider c)
    {
        // print("Here");
        if (c.attachedRigidbody)
        {   
            gameObject.transform.parent.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}

