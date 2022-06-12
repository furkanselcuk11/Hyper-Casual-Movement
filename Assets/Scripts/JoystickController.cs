using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed = 500;

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
            Quaternion temp= Quaternion.LookRotation(rb.velocity, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(transform.rotation, temp, _rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
