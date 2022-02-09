using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToporUPInHands : Entity
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            WeaponsController.Instance.WeaponInHands();
            Die();
        }
    }
}
