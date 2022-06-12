using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    Rigidbody rb;
    private Animator anim;

    [Space]
    [Header("Joystick Controller")]
    [SerializeField] Joystick joystick;   // Joystick scripti
    float vertical, horizontal; // Player yönü  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        JoystickMove();   // Joystick kontrolü çalýþýr 
    }
    public void JoystickMove()
    {
        // Joystick kontrolü
        vertical = joystick.Vertical * _movementSpeed * Time.fixedDeltaTime;
        horizontal = joystick.Horizontal * _movementSpeed * Time.fixedDeltaTime;

        rb.velocity = new Vector3(horizontal, 0, vertical);
        if (rb.velocity != Vector3.zero)
        {
            anim.SetBool("isRunning", true);
            rb.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
