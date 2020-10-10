using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TractorBeamCollider : MonoBehaviour
{
    public GameObject winText;
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            winText.SetActive(true);
        }
    }
}
