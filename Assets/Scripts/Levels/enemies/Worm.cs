using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Entity
{
    [SerializeField] private int lives = 2;
    [SerializeField] private GameObject fiftyPercentOfHealth;
    [SerializeField] private GameObject zeroPercentOfHealth;
    [SerializeField] private Transform healthPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log("у червя " + lives + " жизней");
        }
        else if (collision.gameObject == Topor.Instance.gameObject)
        {
            lives--;
            Debug.Log("у червя " + lives + " жизней");
        }
        HealthPercent();
    }

    private void HealthPercent()
    {
        if (lives == 1)
        {
            Instantiate(fiftyPercentOfHealth, healthPosition.position, Quaternion.Euler(new Vector3(0f, 0f, -25f)));

        }

        if (lives < 1)
        {
            Instantiate(zeroPercentOfHealth, healthPosition.position, Quaternion.Euler(new Vector3(0f, 0f, -15f)));
            Die();
        }
    }
}