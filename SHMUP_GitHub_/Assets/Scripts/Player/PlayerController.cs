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
    public GameObject blaster;
    public GameObject spread;
    public GameObject shield;
    public int health = 3;
    [SerializeField]
    private PlayerEnum _playerAbility = PlayerEnum.None;


    [SerializeField]
    private InputActionReference attack;

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
        if (health <= 0)
        {
            Debug.Log("Dead");
        }
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
        if(_playerAbility == PlayerEnum.None || _playerAbility == PlayerEnum.Shield)
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        }
        
        if(_playerAbility == PlayerEnum.Blaster)
        {
            Instantiate(blaster, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
        }

        if (_playerAbility == PlayerEnum.Spread)
        {
            Instantiate(spread, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        }
    }

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
