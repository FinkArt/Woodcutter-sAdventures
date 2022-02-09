using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    
    public virtual void GetDamage() //����������� virtual ��������� ��� ����, ����� ����� ������������ ������ � �������� �������, �.�. ��� ����� ������ 
    { 

    }

    public virtual void Die ()
    {
        Destroy(this.gameObject);
    }

}
