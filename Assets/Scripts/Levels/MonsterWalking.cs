using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterWalking : Entity
{
    private int lives = 3;
    public float speed;
    private Vector3 dir;

    [SerializeField] private GameObject sixtyPercentOfOfHealth;
    [SerializeField] private GameObject thirtyThreePercentOfHealth;
    [SerializeField] private GameObject zeroPercentOfHealth;
    [SerializeField] private Transform healthPosition;

    private void Start()
    {
        dir = transform.right;
    }

    private void Update()
    {
        Move();

    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 1f + transform.right * dir.x * 1f, 0.02f);

        if (colliders.Length > 0) dir *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        if (dir.x > 0.0f)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log("у монстра " + lives + " жизней");
            HealthPercent();
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Topor")
        {
            Topor.Instance.Die();
            lives--;
            Debug.Log("у монстра " + lives + " жизней");
            HealthPercent();
            
        }
    }
        
    private void HealthPercent()
    {
        if (lives == 2)
        {
            Instantiate(sixtyPercentOfOfHealth, healthPosition.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));

        }
        if (lives == 1)
        {
            Instantiate(thirtyThreePercentOfHealth, healthPosition.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));

        }

        if (lives < 1)
        {
            Instantiate(zeroPercentOfHealth, healthPosition.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
            Die();
        }
    }
}
