using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHealthOfEnemy : MonoBehaviour
{
    private void Update()
    {
        Destroy(this.gameObject, 0.37f);
    }
}
