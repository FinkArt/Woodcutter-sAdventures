using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTree : Entity
{
    [SerializeField] private int health = 1;
    [SerializeField] private GameObject zeroHealth;
    [SerializeField] private Transform healthPosition;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            health--;
            Debug.Log("у дерева " + health + " жизней");
        }
        else if (collision.gameObject == Topor.Instance.gameObject)
        {
            health--;
            Debug.Log("у дерева " + health + " жизней");
        }
        if (health < 1)
        {
            Instantiate(zeroHealth, healthPosition.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
            Destroy(this.gameObject, 0.05f);
        }
    }
}
