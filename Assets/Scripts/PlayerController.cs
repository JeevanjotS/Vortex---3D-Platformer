using System.Collections;
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
        rend = gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<Renderer>();
        countdown_Timer = textBox.GetComponent<Countdown_timer>();
        default_forward_speed = forward_speed;
        default_rotate_speed = rotate_speed;
        for (int i = 0; i < Squee_materials.Length; i++) 
        {
            Material_Dictionary.Add( PowerUp_materials[i], Squee_materials[i]);
        } 
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
            countdown_Timer.addToTimer(10);
        }
        if (c.gameObject.CompareTag("Pickup"))
        {
            c.gameObject.SetActive(false);
            collided_material = c.gameObject.GetComponent<MeshRenderer>().material;
            print(  Squee_materials[0].name);
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
                rotate_speed+=10;
            }
        }


    }
    void Update()
    {
        var kb = Keyboard.current;
        if (kb.spaceKey.isPressed)
        {
            print("Jump Key Pressed!");
        }
    }


}
