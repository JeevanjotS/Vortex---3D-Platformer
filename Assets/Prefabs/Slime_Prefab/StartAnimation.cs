using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private int s = 10;
    public GameObject UVSlimePickUp;
    private GameObject RotatingParent;
    private bool b;
    Animator[] anims;
    void Start()
    {
        RotatingParent = UVSlimePickUp.transform.GetChild(0).gameObject;
        anims = GetComponentsInChildren<Animator>(RotatingParent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider c)
    {
        // b=false;
        // foreach (Collider col in c)
        // {
        if (c.gameObject.name == "Player")
        //     {
        //         b=true;
        //     }
        // }
        // if (b)
        {
            foreach (Animator anim in anims ) 
            {
                anim.SetBool ( "AnimationOn", true);        
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        foreach (Animator anim in anims ) 
        {
            anim.SetBool ( "AnimationOn", false);        
        }
    }
}
