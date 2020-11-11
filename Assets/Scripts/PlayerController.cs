using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    public GameObject deathText;
    public Vector3 direction;
    public float waterDefaultY;
    public float waterFreezeY;

    private Material collided_material;
    private Countdown_timer countdown_Timer;
    private double distanceToGround;
    private Collider col;

    public Material[] Squee_materials;
    public Material[] PowerUp_materials;

    public GameObject textBox;

    public Text powerUpTextBox;
    public Material wallDefaultMaterial;
    public Material wallPhaseMaterial;
    public Material waterDefaultMaterial;
    public Material waterSolidMaterial;
    public Material longWaterDefaultMaterial;
    public Material longWaterSolidMaterial;
    public Color[] ParticleColors;
    public int SlimePickUpTime;

    //Dictonary of format { Power_Up_Material : Character_Material}
    private Dictionary<Material, Material> Material_Dictionary = new Dictionary<Material, Material>();
    private GameObject[] phasable_walls;
    private GameObject[] water_game_objects;
    private GameObject particleSystemGameObject;
    private Vector3 water_pos;
    ParticleSystem particleSystem;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rend = GetComponent<Renderer>();
        rend = gameObject.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.GetComponent<Renderer>();
        countdown_Timer = textBox.GetComponent<Countdown_timer>();
        default_forward_speed = forward_speed;
        default_rotate_speed = rotate_speed;
        for (int i = 0; i < Squee_materials.Length; i++) 
        {
            Material_Dictionary.Add( PowerUp_materials[i], Squee_materials[i]);
        } 
        transform.GetChild(0).gameObject.SetActive(false);
        GlobalVar.projPos = transform.GetChild(0).gameObject.transform.position;
        deathText.SetActive(false);

        // List of phasable wall game objects
        phasable_walls = GameObject.FindGameObjectsWithTag("Phasable");
        water_game_objects = GameObject.FindGameObjectsWithTag("Water");
        // print();
        animator = GetComponentsInChildren<Animator>( this.transform.GetChild(2).gameObject )[0];
        animator.SetBool ( "Moving", false); 
        // print(  animator.name );
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        distanceToGround = col.bounds.extents.y;
        particleSystemGameObject = this.transform.GetChild(2).GetChild(1).gameObject;
        particleSystem = particleSystemGameObject.GetComponent<ParticleSystem>();
        
    }

    private void set_wall_material(Material material)
    {
        for (int i = 0; i < phasable_walls.Length; i++) 
        {
            phasable_walls[i].GetComponent<Renderer>().material = material;
        } 
    }

    private void set_water_material_and_Y(Material material, Material longMaterial, float waterY)
    {
        for (int i = 0; i < water_game_objects.Length; i++) 
        {
            if (water_game_objects[i].name == "Long Water"){
                water_game_objects[i].GetComponent<Renderer>().material = longMaterial;
            }
            else
            {
                water_game_objects[i].GetComponent<Renderer>().material = material;
            }
            water_pos = water_game_objects[i].transform.position;
            water_game_objects[i].transform.position = new Vector3(water_pos.x, waterY, water_pos.z);  
        } 
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
        if ((movementY>=0.01 || movementY<=-0.01 ) && Physics.Raycast(transform.position, - Vector3.up, (float)(distanceToGround)))
        {
            animator.SetBool ( "Moving", true); 
        }
        else
        {
            animator.SetBool ( "Moving", false); 
        }
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
        set_wall_material( wallDefaultMaterial );
        set_water_material_and_Y( waterDefaultMaterial, longWaterDefaultMaterial, waterDefaultY);   
    }

    private void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.name == "RotatingParent"){
            FindObjectOfType<SoundManagerScript>().PlaySoundSlimePickUp();
            countdown_Timer.addToTimer(SlimePickUpTime);
        }
        if (c.gameObject.CompareTag("Pickup"))
        {
            animator.SetBool("PickUp", true);
            animator.SetTrigger("PickUp");
            FindObjectOfType<SoundManagerScript>().PlaySoundPickUp();
            c.gameObject.SetActive(false);
            particleSystemGameObject.SetActive(true);
            collided_material = c.gameObject.GetComponent<MeshRenderer>().material;
            DefaultPower();
            if (collided_material.name.Replace(" (Instance)", "") == "Phasing")
            {
                particleSystem.startColor = ParticleColors[0];
                powerUpTextBox.text = " Power : Phasing";
                rend.material = Squee_materials[1];
                gameObject.layer = LayerMask.NameToLayer("Phasable");
                set_wall_material( wallPhaseMaterial );  
            }
            else if(collided_material.name.Replace(" (Instance)", "") == "Jumping")
            {
                particleSystem.startColor = ParticleColors[1];
                powerUpTextBox.text = " Power : Jumping";
                rend.material = Squee_materials[0];
                gameObject.GetComponent<PlayerJump>().enabled = true;
            }
            else if(collided_material.name.Replace(" (Instance)", "") == "Freezing")
            {
                particleSystem.startColor = ParticleColors[2];
                powerUpTextBox.text = " Power : Freezing";
                rend.material = Squee_materials[2];
                Physics.IgnoreLayerCollision(0, 4, false);
                set_water_material_and_Y( waterSolidMaterial, longWaterSolidMaterial, waterFreezeY );
            }
            else if(collided_material.name.Replace(" (Instance)", "") == "SpeedUp")
            {
                particleSystem.startColor = ParticleColors[3];
                powerUpTextBox.text = " Power : Speed";
                rend.material = Squee_materials[3];
                forward_speed+=100;
                rotate_speed+=1;
            }
        }

        if (c.gameObject.CompareTag("Enemy")) {
                Time.timeScale = 0f;
                deathText.SetActive(true);
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

            direction = transform.GetChild(1).transform.position - transform.GetChild(0).transform.position;
            direction = Vector3.Normalize(direction);
            Vector3 temp = direction;
            temp.y = 0.5f;
            direction = temp;

            transform.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            GlobalVar.projPos = transform.GetChild(0).transform.position;
            // transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(velDir * impulseForce, force);
            transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(direction * impulseForce, force);
            FindObjectOfType<SoundManagerScript>().PlaySoundFire();
        }
    }
}

