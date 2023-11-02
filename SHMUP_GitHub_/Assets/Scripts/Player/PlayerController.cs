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
    [SerializeField]
    private InputActionReference attack;

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
        attack.action.performed += PerformAttack;
    }
    public void OnDisable()
    {
        playerControls.Disable();
        attack.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        Debug.Log("Attack");
    }
}
