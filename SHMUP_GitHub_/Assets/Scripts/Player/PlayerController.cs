using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//
//
//10/24/23

public class PlayerController : MonoBehaviour
{
    public InputAction playerControls;
    public Rigidbody rb;
    Vector2 moveDirection = Vector2.zero;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }




    public void OnEnable()
    {
        playerControls.Enable();
    }
    public void OnDisable()
    {
        playerControls.Disable();
    }
}