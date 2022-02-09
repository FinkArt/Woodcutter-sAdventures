using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 finishPos = Vector3.zero;
    public float speed = 1f;

    private Vector3 startPos;
    private Vector3 dir;

    private void Start()
    {
        dir = transform.right;
        startPos = transform.position;
    }

    private void Update()
    {

        MoveRight();
        if (transform.position.x >= finishPos.x || transform.position.x <= startPos.x)
        {
            //MoveRight();
            dir *= -1;
        }
       
    }

    private void MoveRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

}
