using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvlButton : MonoBehaviour
{
    [SerializeField] Sprite unlockButton;
    [SerializeField] Sprite lockButton;

    public static int countUnlockLevel = 1; //переменная для обозначения количества открытых уровней
   
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            int numLvl = i + 1;
            transform.GetChild(i).gameObject.name = numLvl.ToString ();
            transform.GetChild(i).transform.GetChild(0).GetComponent <Text>().text = numLvl.ToString();
            
            if (i < countUnlockLevel)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = unlockButton;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }

            else
            {
                transform.GetChild(i).GetComponent<Image>().sprite = lockButton;
                transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
    }

}
