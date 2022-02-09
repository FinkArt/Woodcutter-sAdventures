using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : Entity
{
    [SerializeField] private float speed = 5f; //������ �������� 
    [HideInInspector] private int lives; // ���������� ��������
    [SerializeField] public static int health; //���-�� ������
    [SerializeField] private float jumpForce = 11f; // ������ ���� ������
    private bool isGronded = false;

    private Rigidbody2D rb;
    private Animator anim;
    //private SpriteRenderer sprite; - ����� ���� ��� ���������� �������� ����� ������ sprite.flipX = dir.x < 0.0f;
    [HideInInspector] public bool isRight = true;
    public static Hero Instance { get; set; } //����� ����������� (� ������� ����� �������� ��������) �� ���� ��������� ����� � ������� ������ Hero, �� �������� ��� ������������

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite deadHeart;

    private States State
    {
        get { return (States)anim.GetInteger("State"); } // c ������� ���� �������� �������� ����� �� ���������
        set { anim.SetInteger("State", (int)value); } //C ������� ��� ������ �������� �����

    }

    private void Awake()
    {
        lives = 3;
        health = lives;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //sprite = GetComponentInChildren<SpriteRenderer>(); - ����� ���� ��� ���������� �������� ����� ������ sprite.flipX = dir.x < 0.0f;
        Instance = this; //����������� ����� ���������������� Instance 

    }
    private void Update()
    {
        if (isGronded) State = States.Idle; //������ �������� ������ ���� �� ����� �� ����� 

        if (Input.GetButton("Horizontal") && !PauseMenu.isPaused) //������������� �������, ��� �������� �� ��������� ��� ���� �����, ������ ������ �� ����� PauseMenu
            Run();
        if (Input.GetButtonDown("Jump") && isGronded && !PauseMenu.isPaused) //������������� �������, ��� �������� �� ��������� ��� ���� �����, ������ ������ �� ����� PauseMenu
            Jump();

        if (health > lives) //������������ �������� ������������ ����������� ������
            health = lives;
        for (int i = 0; i < hearts.Length; i++) //���� ��� ������ �������� �������� � ������� �� ������ � ����������� �� ���������� ������
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

    private void Run() //����� ����� ������
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal"); // ������ ���������� ��� ����������� �������� ���������
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        if (dir.x < 0.0f)                                  // �������� ������� �� ������� ��������� ������������ ��� �
        {
            transform.localScale = new Vector3(-1, 1, 1); // ������������ ��������� ����� 
            isRight = false;
        }
        else if (dir.x > 0.0f)                                  // �������� ������� �� ������� ��������� ������������ ��� �
        {
            transform.localScale = new Vector3(1, 1, 1);   // ������������ ��������� ������
            isRight = true;
        }

        if (isGronded) State = States.Run;       //������ �������� ������ �� ����� ����
    }

    private void Jump() //����� ����� �������
    {
       rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGrounded () //�������� ������ ���� �� ����� ��� ������
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGronded = collider.Length > 1;
        
        if (!isGronded) State = States.Jump;
    }

    public enum States //������ ���������� ��� ���������� �������� ���������
    {
        Idle,
        Run,
        Jump
    }

    public override void GetDamage ()   //����� �� ��������� ����� , �.�. �������� ����� , ����� ����� �������� � ����������� ��� ������ 
    {
        health  -= 1;
        Debug.Log("� ������ " + health + " ������");

        if (health < 1)
        {
            foreach (var j in hearts)
                j.sprite = deadHeart;
            Die();
           
        }
    }

    public void HeartPlusOne() //����� ��� ���������� �������� ��� ������ ��������
    {
        health = health + 1;
    }

}
