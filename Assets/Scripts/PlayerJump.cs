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
    private double distanceToGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        distanceToGround = col.bounds.extents.y;

    }

    // Update is called once per frame
    void Update()
    {
        // print(this.name);
        var kb = Keyboard.current;
        if (kb.spaceKey.wasPressedThisFrame)
        {
            if(Physics.Raycast(transform.position, - Vector3.up, (float)(distanceToGround)))
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);   
            }
        }

    }
}
