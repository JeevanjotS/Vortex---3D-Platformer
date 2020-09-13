using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Renderer rend;
    public GameObject winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        winText.SetActive(false);
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
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Pickup"))
        {
            c.gameObject.SetActive(false);
            rend.material = c.gameObject.GetComponent<MeshRenderer>().material;
            if (rend.material.name.Replace(" (Instance)", "") == "Phasing")
            {
                gameObject.GetComponent<PlayerJump>().enabled = false;
                gameObject.layer = LayerMask.NameToLayer("Phasable");
            }
            else if(rend.material.name.Replace(" (Instance)", "") == "Jumping")
            {
                gameObject.GetComponent<PlayerJump>().enabled = true;
                gameObject.layer = LayerMask.NameToLayer("Default");
            }
            else
            {
                gameObject.GetComponent<PlayerJump>().enabled = false;
                gameObject.layer = LayerMask.NameToLayer("Default");
            }
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
