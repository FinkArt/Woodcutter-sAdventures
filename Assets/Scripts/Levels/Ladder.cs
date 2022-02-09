using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            //other.GetComponent<Rigidbody2D>().gravityScale = 0;
            Physics2D.gravity = new Vector2(0, 0);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

            }

            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Hero"))
        // other.GetComponent<Rigidbody2D>().gravityScale = 3f;
        Physics2D.gravity = new Vector2(0, -9.81f);
    }

}
