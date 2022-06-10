using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperCasualMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed=500;

    private Touch _touch;   // Ekrana dokunmay� alg�lama
    private Vector3 _touchDown; // ilk dokunulan yer
    private Vector3 _touchUp;   // Son dokunulan yer

    private Rigidbody rb;
    private bool _dragStarted;  // S�r�klemenin ba�lan�p ba�lanmad���
    private bool _isMoving; // Hareket ediyor mu

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount>0) // Ekrana dokunulmu�sa
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)   // Dokunma ba�lady�sa
            {
                _dragStarted = true;    // Dokunma/s�r�klenme ba�lanm��t�r
                _isMoving = true;   // Hareket ediyor
                _touchDown = _touch.position;   // Dokundu�u yerin pozisyonunu al
                _touchUp= _touch.position;  // Dokundu�u yerin pozisyonunu al
            }
        }
        if (_dragStarted)   // Oyuncu s�r�kleme i�lemi yapt�ysa
        {
            if (_touch.phase == TouchPhase.Moved)
            {
                // E�er oyuncu karakteri hareket ettiriyorsa
                _touchDown = _touch.position;   // Hareket etti�i s�rece pozisyonunu al
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                // E�er oyuncu karakteri hareket ettirmeyi bitirdiyse
                _touchDown = _touch.position;   // Hareket etti�i son pozisyonunu al
                _isMoving = false;  // Hareket etmiyor
                _dragStarted = false;   // S�r�kleme yapm�yor
            }
            // Karakter kendi ekseni etraf�nda d�ner            
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
        // Karakteri etraf�nda �evirir
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);    
        return temp;
    }
    Vector3 CalculateDirection()
    {
        // Karakterin ba�lad��� ve bitirdi�i yerin fark�n� al�r
        Vector3 temp = (_touchDown - _touchUp).normalized;  // Normal ile de�erini k���lt�r
        temp.z = temp.y;    // Yukar� y�nde hareket etmemesi i�in y pozisyonuna e�itliyoruz
        temp.y = 0;
        return temp;
    }
}
