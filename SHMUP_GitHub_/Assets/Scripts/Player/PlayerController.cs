using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//Jack Bradford
//Controls the player
//10/24/23

public class PlayerController : MonoBehaviour
{
    public InputAction playerControls;
    public Rigidbody rb;
    Vector2 moveDirection = Vector2.zero;
    public float moveSpeed;
    public GameObject bullet;
    public GameObject blaster;
    public GameObject spread;
    public GameObject shield;
    public int health = 3;
    [SerializeField]
    private PlayerEnum _playerAbility = PlayerEnum.None;


    [SerializeField]
    private InputActionReference attack;

    //Sets this player as the singleton
    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }

    //If health above 0, get the players movement
    void Update()
    {
        if (health > 0)
        {
            moveDirection = playerControls.ReadValue<Vector2>();
        }

        
    }

    //Move the player
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    //On Enable/Disable, every video I watched said its good to have these with new unity input but none said why
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


    //Perform the player attack, and change projectile if they have a powerup
    private void PerformAttack(InputAction.CallbackContext obj)
    {
        if(health > 0)
        {
            if (_playerAbility == PlayerEnum.None || _playerAbility == PlayerEnum.Shield)
            {
                Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            }

            if (_playerAbility == PlayerEnum.Blaster)
            {
                Instantiate(blaster, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
            }

            if (_playerAbility == PlayerEnum.Spread)
            {
                Instantiate(spread, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            }
        }
        
    }

    //Collisions
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(_playerAbility == PlayerEnum.Shield)
            {
                Debug.Log("Shielded");
            }
            else
            {
                health -= 1;
            }
        }

        if (collision.gameObject.tag == "Blaster")
        {
            _playerAbility = PlayerEnum.Blaster;
            StartCoroutine(BlasterActivate());
        }

        if (collision.gameObject.tag == "Spread")
        {
            _playerAbility = PlayerEnum.Spread;
            StartCoroutine(SpreadActivate());
        }

        if (collision.gameObject.tag == "Shield")
        {
            _playerAbility = PlayerEnum.Shield;
            StartCoroutine(ShieldActivate());
        }
    }

    //Determine how long each powerup lasts for, and change the Enum of the player
    IEnumerator ShieldActivate()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(5);
        shield.SetActive(false);
        _playerAbility = PlayerEnum.None;
    }

    IEnumerator BlasterActivate()
    {
        yield return new WaitForSeconds(5);
        _playerAbility = PlayerEnum.None;
    }

    IEnumerator SpreadActivate()
    {
        yield return new WaitForSeconds(5);
        _playerAbility = PlayerEnum.None;
    }
}
