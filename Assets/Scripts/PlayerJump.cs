using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpPower = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var kb = Keyboard.current;
        if (kb.spaceKey.isPressed)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

    }
}
