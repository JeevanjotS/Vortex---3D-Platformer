using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.EventSystems;

public class CollectableSlime : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        // print("Here");
        if (c.attachedRigidbody)
        {   
            this.gameObject.SetActive(false);
        }
    }
}

