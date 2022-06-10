using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperCasualMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed=500;

    private Touch _touch;   // Ekrana dokunmayý algýlama
    private Vector3 _touchDown; // ilk dokunulan yer
    private Vector3 _touchUp;   // Son dokunulan yer

    private Rigidbody rb;
    private bool _dragStarted;  // Sürüklemenin baþlanýp baþlanmadýðý
    private bool _isMoving; // Hareket ediyor mu

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount>0) // Ekrana dokunulmuþsa
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)   // Dokunma baþladyýsa
            {
                _dragStarted = true;    // Dokunma/sürüklenme baþlanmýþtýr
                _isMoving = true;   // Hareket ediyor
                _touchDown = _touch.position;   // Dokunduðu yerin pozisyonunu al
                _touchUp= _touch.position;  // Dokunduðu yerin pozisyonunu al
            }
        }
        if (_dragStarted)   // Oyuncu sürükleme iþlemi yaptýysa
        {
            if (_touch.phase == TouchPhase.Moved)
            {
                // Eðer oyuncu karakteri hareket ettiriyorsa
                _touchDown = _touch.position;   // Hareket ettiði sürece pozisyonunu al
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                // Eðer oyuncu karakteri hareket ettirmeyi bitirdiyse
                _touchDown = _touch.position;   // Hareket ettiði son pozisyonunu al
                _isMoving = false;  // Hareket etmiyor
                _dragStarted = false;   // Sürükleme yapmýyor
            }
            // Karakter kendi ekseni etrafýnda döner            
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), _rotationSpeed * Time.deltaTime);
            // Karakter ileri hareker eder
            gameObject.transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
        }

        if (_isMoving && _dragStarted)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    Quaternion CalculateRotation()
    {
        // Karakteri etrafýnda çevirir
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);    
        return temp;
    }
    Vector3 CalculateDirection()
    {
        // Karakterin baþladýðý ve bitirdiði yerin farkýný alýr
        Vector3 temp = (_touchDown - _touchUp).normalized;  // Normal ile deðerini küçültür
        temp.z = temp.y;    // Yukarý yönde hareket etmemesi için y pozisyonuna eþitliyoruz
        temp.y = 0;
        return temp;
    }
}
