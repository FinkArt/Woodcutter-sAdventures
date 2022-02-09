using UnityEngine;

public class DieSpace : Entity
{
    public GameObject Respown;
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Hero")
        {
            other.transform.position = Respown.transform.position;
            Hero.Instance.GetDamage();
        }

    }
}
