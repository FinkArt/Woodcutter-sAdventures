using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : Entity
{
    [SerializeField] private float speed = 5f; //«адаем скорость 
    [HideInInspector] private int lives; // переменна€ здоровь€
    [SerializeField] public static int health; //кол-во жизней
    [SerializeField] private float jumpForce = 11f; // «адаем силу прыжка
    private bool isGronded = false;

    private Rigidbody2D rb;
    private Animator anim;
    //private SpriteRenderer sprite; - нужно было дл€ реализации поворота через способ sprite.flipX = dir.x < 0.0f;
    [HideInInspector] public bool isRight = true;
    public static Hero Instance { get; set; } //можем обращаетьс€ (с помощью этого паттерна —инглтон) ко всем публичным пол€м и методам класса Hero, не создава€ его эксземпл€ров

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite deadHeart;

    private States State
    {
        get { return (States)anim.GetInteger("State"); } // c помощью √ета получаем значение —тэйт из аниматора
        set { anim.SetInteger("State", (int)value); } //C помощью —эт мен€ем значение —тэйт

    }

    private void Awake()
    {
        lives = 3;
        health = lives;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //sprite = GetComponentInChildren<SpriteRenderer>(); - нужно было дл€ реализации поворота через способ sprite.flipX = dir.x < 0.0f;
        Instance = this; //об€зательно нужно инициализировать Instance 

    }
    private void Update()
    {
        if (isGronded) State = States.Idle; //задает анимацию игроку пока он стоит на месте 

        if (Input.GetButton("Horizontal") && !PauseMenu.isPaused) //устанавливаем условие, что персонаж не двигаетс€ при меню паузы, делаем ссылку на класс PauseMenu
            Run();
        if (Input.GetButtonDown("Jump") && isGronded && !PauseMenu.isPaused) //устанавливаем условие, что персонаж не двигаетс€ при меню паузы, делаем ссылку на класс PauseMenu
            Jump();

        if (health > lives) //ограничиваем здоровье максимальным количеством жизней
            health = lives;
        for (int i = 0; i < hearts.Length; i++) //цикл дл€ замены сердечек здоровь€ с полного на пустое в зависимости от количества жизней
        {
            if (i < health)
                hearts[i].sprite = aliveHeart;
            else 
                hearts[i].sprite = deadHeart;
            if (i < lives)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    private void FixedUpdate() 
    {
        CheckGrounded();
        
    }

    private void Run() //метод чтобы бежать
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal"); // «адаем переменную дл€ направлени€ движени€ персонажа
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        if (dir.x < 0.0f)                                  // проверка услови€ на поворот персонажа относительно оси ’
        {
            transform.localScale = new Vector3(-1, 1, 1); // поворачивает персонажа влево 
            isRight = false;
        }
        else if (dir.x > 0.0f)                                  // проверка услови€ на поворот персонажа относительно оси ’
        {
            transform.localScale = new Vector3(1, 1, 1);   // поворачивает персонажа вправо
            isRight = true;
        }

        if (isGronded) State = States.Run;       //задает анимацию игроку во врем€ бега
    }

    private void Jump() //метод чтобы прыгать
    {
       rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGrounded () //ѕроверка метода ≈сть ли земл€ под ногами
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGronded = collider.Length > 1;
        
        if (!isGronded) State = States.Jump;
    }

    public enum States //задаем переменные дл€ реализации анимации персонажа
    {
        Idle,
        Run,
        Jump
    }

    public override void GetDamage ()   //метод на нанесение урона , т.е. отнимает жизнь , когда игрок коснетс€ с преп€тсвием или врагом 
    {
        health  -= 1;
        Debug.Log("у игрока " + health + " жизней");

        if (health < 1)
        {
            foreach (var j in hearts)
                j.sprite = deadHeart;
            Die();
           
        }
    }

    public void HeartPlusOne() //метод дл€ увеличени€ здоровь€ при вз€тии сердечка
    {
        health = health + 1;
    }

}
