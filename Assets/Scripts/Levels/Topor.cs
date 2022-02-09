using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topor : Entity
{
    public float toporSpeed = 5f; //�������� �� �������� ������
    public Rigidbody2D topor;
    public static Topor Instance { get; set; } //���� ������ � ������� ������ � ������ �������

    private void Awake()
    {
        Instance = this; //����������� ��������� this � ������ ������
    }
    private void FixedUpdate()
    {
        topor.velocity = transform.right * toporSpeed; //������ �������� ������ ������� � ������������ �����������
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Die();  //������� ������ ������ ��� ������������ � ������� ������������
    }
    
}
