using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float speed = 30f;    // Player hareket h�z�
    [SerializeField] private float horizontalspeed = 10f; // Player y�n hareket h�z�
    [SerializeField] private float defaultSwipe = 4f;    // // Player default kayd�rma mesafesi

    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.fixedDeltaTime);
        MoveInput();    // Player hareket kontrol�
    }

    void MoveInput()
    {
        #region Mobile Controller 2 Direction

        //float moveX = transform.position.x; // Player objesinin x pozisyonun de�erini al�r
        //float moveZ = transform.position.z; // Player objesinin z pozisyonun de�erini al�r 

        //anim.SetBool("isRunning", true);

        //if (Input.GetKey(KeyCode.LeftArrow) || MobileInput.instance.swipeLeft)
        //{   // E�er klavyede sol ok tu�una bas�ld�ysa yada "MobileInput" scriptinin swipeLeft de�eri True ise  Sola gider               
        //    moveX = Mathf.Clamp(moveX - 1 * horizontalspeed * Time.fixedDeltaTime, -defaultSwipe, defaultSwipe);  // Pozisyon s�n�rland�r�lmas� koyulacaksa
        //    // Player objesinin x (sol) pozisyonundaki gidece�i min-max s�n�r� belirler
        //    //moveX = moveX - 1 * horizontalspeed * Time.fixedDeltaTime;  // Pozisyon s�n�rland�r�lmas� yoksa        
        //}
        //else if (Input.GetKey(KeyCode.RightArrow) || MobileInput.instance.swipeRight)
        //{   // E�er klavyede sa� ok tu�una bas�ld�ysa yada "MobileInput" scriptinin swipeRight de�eri True ise Sa�a gider         
        //    moveX = Mathf.Clamp(moveX + 1 * horizontalspeed * Time.fixedDeltaTime, -defaultSwipe, defaultSwipe);  // Pozisyon s�n�rland�r�lmas� koyulacaksa
        //    // Player objesinin  x (sa�) pozisyonundaki gidece�i min-max s�n�r� belirler
        //    //moveX = moveX + 1 * horizontalspeed * Time.fixedDeltaTime;  // Pozisyon s�n�rland�r�lmas� yoksa                  
        //}
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{   // E�er klavyede yukar� ok tu�una bas�ld�ysa yada "MobileInput" scriptinin swipeUp de�eri True ise �leri hareket gider         
        //    moveZ = moveZ + 1 * speed * Time.fixedDeltaTime;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{   // E�er klavyede a�a�� ok tu�una bas�ld�ysa yada "MobileInput" scriptinin swipeDown de�eri True ise Geri hareket gider         
        //    moveZ = moveZ - 1 * speed * Time.fixedDeltaTime;
        //}
        //else
        //{
        //    rb.velocity = Vector3.zero; //E�er sa�-sol hareket yap�lmad�ysa Player objesi sabit kals�n
        //}
        //transform.position = new Vector3(moveX, transform.position.y, moveZ);
        //// Player objesinin pozisyonu moveX de�erine g�re x ekseninde sa�-sol hareket eder

        #endregion

        #region Mobile Controller 4 Direction

        float moveX = transform.position.x; // Player objesinin x pozisyonun de�erini al�r      
        float moveZ = transform.position.z; // Player objesinin z pozisyonun de�erini al�r   

        anim.SetBool("isRunning", true);

        if (Input.GetKey(KeyCode.LeftArrow) || MobileInput.instance.swipeLeft)
        {   // E�er klavyede sol ok tu�una bas�ld�ysa yada "MobileInput" scriptinin swipeLeft de�eri True ise  Sola hareket gider
            moveX = Mathf.Clamp(moveX - 1 * horizontalspeed * Time.fixedDeltaTime, -defaultSwipe, defaultSwipe);    // Pozisyon s�n�rland�r�lmas� koyulacaksa
            // Player objesinin x (sol) pozisyonundaki gidece�i min-max s�n�r� belirler
            //moveX = moveX - 1 * horizontalspeed * Time.fixedDeltaTime;    // Pozisyon s�n�rland�r�lmas� yoksa 
        }
        else if (Input.GetKey(KeyCode.RightArrow) || MobileInput.instance.swipeRight)
        {   // E�er klavyede sa� ok tu�una bas�ld�ysa yada "MobileInput" scriptinin swipeRight de�eri True ise Sa�a hareket gider  
            moveX = Mathf.Clamp(moveX + 1 * horizontalspeed * Time.fixedDeltaTime, -defaultSwipe, defaultSwipe);    // Pozisyon s�n�rland�r�lmas� koyulacaksa
            // Player objesinin x (sa�) pozisyonundaki gidece�i min-max s�n�r� belirler
            //moveX = moveX + 1 * horizontalspeed * Time.fixedDeltaTime;    // Pozisyon s�n�rland�r�lmas� yoksa 
        }
        //else if (Input.GetKey(KeyCode.UpArrow) || MobileInput.instance.swipeUp)
        //{   // E�er klavyede yukar� ok tu�una bas�ld�ysa yada "MobileInput" scriptinin swipeUp de�eri True ise �leri hareket gider         
        //    moveZ = moveZ + 1 * speed * Time.fixedDeltaTime;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow) || MobileInput.instance.swipeDown)
        //{   // E�er klavyede a�a�� ok tu�una bas�ld�ysa yada "MobileInput" scriptinin swipeDown de�eri True ise Geri hareket gider         
        //    moveZ = moveZ - 1 * speed * Time.fixedDeltaTime;
        //}
        else
        {
            rb.velocity = Vector3.zero; // E�er hareket edilmediyse Player objesi sabit kals�n
        }

        transform.position = new Vector3(moveX, transform.position.y, moveZ);
        // Player objesinin pozisyonu moveX de�erine g�re x ekseninde, moveZ de�erine g�re z ekseninde hareket eder ve y ekseninde sabit kal�r 

        #endregion
    }
}