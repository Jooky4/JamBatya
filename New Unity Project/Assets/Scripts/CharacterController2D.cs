using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    private AudioClip soundJump;
    private AudioSource audioSourceJump;
    public float speed = 10;          // скорость перемещения
    [SerializeField]
    private float speedMoveLadder = 10;
    public float jumpForce = 10;      // скорость прыжка
    [SerializeField]
    private bool isGround = false;    // флаг земля
    private Rigidbody2D rigidbody2D;
    private float horizontal;         //ось горизонт 
    private float vertical;            //ось вертикаль
    private bool Jumped = false;        // флаг прыжок
    private bool facingRight = true;   // куда повернут
    [SerializeField]
    private bool isLadder = false;     // флаг лесницы
    [SerializeField]
    private bool isjump = false;       // флаг прыжок
    public KeyCode action = KeyCode.E; // клавиша действия
    public bool isStop = true;

  

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();   // кеш тела
        audioSourceJump = gameObject.AddComponent<AudioSource>();
        audioSourceJump.playOnAwake = false;
        audioSourceJump.volume = 0.5f;
        audioSourceJump.clip = soundJump;

    }

    // Update is called once per frame
    void Update()
    {
        if (isStop)
        {
            UpdateAxis();
            UpdateFlip();
            UpdateMoveLadder();
        }
    }

    private void FixedUpdate()
    {
        if (isStop)
        {
            Move();
            Jump();
        }
     
       

    }

    /// <summary>
    /// опрос кнопок
    /// </summary>
    void UpdateAxis()  
    {
        Jumped = Input.GetButtonDown("Jump");        // прыжок
        horizontal = Input.GetAxis("Horizontal");   // A   D
        vertical = Input.GetAxis("Vertical");        // W   S

        if (Input.GetKeyDown(action))              // E
        {

        }

    }


    /// <summary>
    /// Метод для действия
    /// </summary>
    void Action()
    {

    }

    /// <summary>
    /// Проверка на движение в противополжую сторону
    /// </summary>
    void UpdateFlip()
    {
        if (horizontal > 0 && !facingRight)
            Flip();
        else if (horizontal < 0 && facingRight)
            Flip();
    }


    /// <summary>
    /// Переворот противоположную сторону
    /// </summary>
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    /// <summary>
    /// Движение вправо влево
    /// </summary>
    private void Move()
    {
       rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);
    }

    /// <summary>
    /// Прыжок
    /// </summary>
    private void Jump()
    {
        if (Jumped) // если нажата пробел
        {
            if (isGround) // если на земле 
            {
               rigidbody2D.AddForce(Vector2.up * jumpForce); // прыгай 
               audioSourceJump.Play();
            }
            isGround = false;  // не на земле 
            isjump = true;     // в прыжке
            
        }
    }


    /// <summary>
    /// проверка на землю 
    /// </summary>
    /// <param name="coll"></param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")  // если обьект столкновения имеет Тег= земля
        {
            isGround = true;  // это земля
            isjump = false;   // не прыгаем

        }
      
    }

    /// <summary>
    /// Проверка входа на лесницу
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ladder")   // если таг лесница
        {
            isLadder = true;     // это лесница
        }
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

    }

    /// <summary>
    /// выход с лесницы
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ladder")
        {
            isLadder = false;
        }
     }

    /// <summary>
    /// Движение по лесницы
    /// </summary>
    void UpdateMoveLadder()   // Пока так дальше  будем  переделывать
    {
        if (isLadder) // если на леснице
        {
            if (vertical != 0) // если нажаты   W или  S
            {
                transform.Translate(new Vector2(0, speedMoveLadder * vertical * Time.fixedDeltaTime)); // движение по лестнице
                isGround = false; // не на  земле
            }

            if (!isGround && !isjump)  // если не на земле и не в прыжке
            {

                rigidbody2D.gravityScale = 0;  // откл гравитацию
            }

        }
        else
        {
            rigidbody2D.gravityScale = 1;     // вкл гравитацию
        }




    }
}
