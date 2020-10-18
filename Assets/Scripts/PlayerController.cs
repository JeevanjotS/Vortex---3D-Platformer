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
    private float default_forward_speed = 0;
    private float default_rotate_speed = 0;
    public float impulseForce = 10f;
    public ForceMode force = ForceMode.Impulse;

    private Material collided_material;
    private Countdown_timer countdown_Timer;

    public Material[] Squee_materials;
    public Material[] PowerUp_materials;

    public GameObject textBox;

    //Dictonary of format { Power_Up_Material : Character_Material}
    private Dictionary<Material, Material> Material_Dictionary = new Dictionary<Material, Material>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rend = GetComponent<Renderer>();
        rend = gameObject.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.GetComponent<Renderer>();
        countdown_Timer = textBox.GetComponent<Countdown_timer>();
        default_forward_speed = forward_speed;
        default_rotate_speed = rotate_speed;
        for (int i = 0; i < Squee_materials.Length; i++) 
        {
            Material_Dictionary.Add( PowerUp_materials[i], Squee_materials[i]);
        } 
        transform.GetChild(0).gameObject.SetActive(false);
        GlobalVar.projPos = transform.GetChild(0).gameObject.transform.position;
    }

    void OnMove(InputValue movementValue)
    {
        if (!transform.GetChild(0).gameObject.activeSelf) {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
            movementY = movementVector.y;
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
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
        if (c.gameObject.name == "RotatingParent"){
            FindObjectOfType<SoundManagerScript>().PlaySoundSlimePickUp();
            countdown_Timer.addToTimer(20);
        }
        if (c.gameObject.CompareTag("Pickup"))
        {
            FindObjectOfType<SoundManagerScript>().PlaySoundPickUp();
            c.gameObject.SetActive(false);
            collided_material = c.gameObject.GetComponent<MeshRenderer>().material;
            DefaultPower();
            if (collided_material.name.Replace(" (Instance)", "") == "Phasing")
            {
                rend.material = Squee_materials[1];
                gameObject.layer = LayerMask.NameToLayer("Phasable");
            }
            else if(collided_material.name.Replace(" (Instance)", "") == "Jumping")
            {
                rend.material = Squee_materials[0];
                gameObject.GetComponent<PlayerJump>().enabled = true;
            }
            else if(collided_material.name.Replace(" (Instance)", "") == "Freezing")
            {
                rend.material = Squee_materials[2];
                Physics.IgnoreLayerCollision(0, 4, false);
            }
            else if(collided_material.name.Replace(" (Instance)", "") == "SpeedUp")
            {
                rend.material = Squee_materials[3];
                forward_speed+=25;
                rotate_speed+=4;
            }
        }


    }
    void Update()
    {

    }

    void OnFire()
    {
        if (!transform.GetChild(0).gameObject.activeSelf && (gameObject.GetComponent<Rigidbody>().velocity == new Vector3(0f, 0f, 0f)) && (gameObject.GetComponent<Rigidbody>().angularVelocity == new Vector3(0f, 0f, 0f))) {
            transform.GetChild(0).gameObject.SetActive(true);
            Vector3 velDir = new Vector3(0, 0.5f, 1.3f);
            transform.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            GlobalVar.projPos = transform.GetChild(0).transform.position;
            transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(velDir * impulseForce, force);
        }
    }
}
