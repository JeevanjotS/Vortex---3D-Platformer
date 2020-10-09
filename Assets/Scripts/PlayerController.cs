﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float forward_speed = 0;
    public float rotate_speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Renderer rend;
    public GameObject winText;
    private float default_forward_speed = 0;
    private float default_rotate_speed = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        winText.SetActive(false);
        default_forward_speed = forward_speed;
        default_rotate_speed = rotate_speed;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        // rb.AddForce(movement * forward_speed);
        rb.AddForce(transform.forward * movementY * forward_speed);
        transform.Rotate(0,movementX * rotate_speed,0);
    }

    //Function to set everything to default
    void DefaultPower()
    {
        gameObject.GetComponent<PlayerJump>().enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Default");
        
        // 0 - Default Layer
        // 4 - Water Layer  
        Physics.IgnoreLayerCollision(0, 4, true);

        // Set forward_speed and rotate speed to original values
        forward_speed = default_forward_speed;
        rotate_speed = default_rotate_speed;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Pickup"))
        {
            c.gameObject.SetActive(false);
            rend.material = c.gameObject.GetComponent<MeshRenderer>().material;
            DefaultPower();
            if (rend.material.name.Replace(" (Instance)", "") == "Phasing")
            {
                //gameObject.GetComponent<PlayerJump>().enabled = false;
                gameObject.layer = LayerMask.NameToLayer("Phasable");
                
                // 0 - Default Layer
                // 4 - Water Layer  
                // Physics.IgnoreLayerCollision(0, 4, true);
            }
            else if(rend.material.name.Replace(" (Instance)", "") == "Jumping")
            {
                gameObject.GetComponent<PlayerJump>().enabled = true;
                // gameObject.layer = LayerMask.NameToLayer("Default");
                // Physics.IgnoreLayerCollision(0, 4, true);
            }
            else if(rend.material.name.Replace(" (Instance)", "") == "Freezing")
            {
                print(" Picked Up Freezing ");
                // gameObject.GetComponent<PlayerJump>().enabled = false;
                // gameObject.layer = LayerMask.NameToLayer("Default");
                Physics.IgnoreLayerCollision(0, 4, false);
            }
            else if(rend.material.name.Replace(" (Instance)", "") == "SpeedUp")
            {
                forward_speed+=25;
                rotate_speed+=10;
            }
            // else
            // {
            //     gameObject.GetComponent<PlayerJump>().enabled = false;
            //     gameObject.layer = LayerMask.NameToLayer("Default");
            //     Physics.IgnoreLayerCollision(0, 4, true);
            // }
        }
        else if(c.gameObject.CompareTag("EndFlag"))
        {
            winText.SetActive(true);
        }

    }
    void Update()
    {
        var kb = Keyboard.current;
        if (kb.spaceKey.isPressed)
        {
            print("Jump Key Pressed!");
        }
        else
        {
            print("");
        }

    }


}
