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
    public GameObject bullet;
    public int health;


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
        //Debug.Log("Attack");
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }

        if (collision.gameObject.tag == "Blaster")
        {
            Debug.Log("Blaster");
        }

        if (collision.gameObject.tag == "Spread")
        {
            Debug.Log("Spread");
        }

        if (collision.gameObject.tag == "Shield")
        {
            Debug.Log("Shield");
        }
    }
}
