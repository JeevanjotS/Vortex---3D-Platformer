using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    public float jumpPower = 10;

    public bool jumpActive = false;
    private double distanceToGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        distanceToGround = col.bounds.extents.y;
        // print("JumpStarted");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnJump() {
        if (jumpActive){
            if (Physics.Raycast(transform.position, - Vector3.up, (float)(distanceToGround)))
            {
                FindObjectOfType<SoundManagerScript>().PlaySoundJump();
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);   
            }
        }
    }
}
