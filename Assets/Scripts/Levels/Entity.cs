using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    
    public virtual void GetDamage() //модификатор virtual требуется для того, чтобы потом переназначит методы в дочерних классах, т.к. все враги разные 
    { 

    }

    public virtual void Die ()
    {
        Destroy(this.gameObject);
    }

}
