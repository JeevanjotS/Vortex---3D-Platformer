using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSpaceship : MonoBehaviour
{
    //public Animation youranimation;
    public GameObject jet;

    void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.CompareTag("Player"))
        {
            Animator jetAnimator = jet.GetComponent<Animator>();
            jetAnimator.SetTrigger("descend");
        }
    }
    void OnTriggerExit(Collider c)
    {

        if (c.gameObject.CompareTag("Player"))
        {
            Animator jetAnimator = jet.GetComponent<Animator>();
            jetAnimator.SetTrigger("reset");
        }
    }

}
