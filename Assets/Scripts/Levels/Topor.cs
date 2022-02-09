using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topor : Entity
{
    public float toporSpeed = 5f; //отвечает за скорость топора
    public Rigidbody2D topor;
    public static Topor Instance { get; set; } //даем доступ к данному классу в других классах

    private void Awake()
    {
        Instance = this; //обязательно прописать this в данном методе
    }
    private void FixedUpdate()
    {
        topor.velocity = transform.right * toporSpeed; //задаем скорость полета снаряда в определенном направлении
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Die();  //удаляем объект топора при столкновении с другими коллайдерами
    }
    
}
