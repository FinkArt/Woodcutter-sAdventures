using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastPoint : MonoBehaviour
{
    private int finalScoreMushrooms;
    public GameObject messageAboutMushrooms;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            if (ScoreMushroom.scoreOfMushrooms < 10)
            {
                messageAboutMushrooms.SetActive (true);
            }

            if (ScoreMushroom.scoreOfMushrooms >= 10)
            {
                LvlButton.countUnlockLevel = 2;
                Debug.Log("Вы прошли на второй уровень");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            messageAboutMushrooms.SetActive(false);
            //messageAboutMushrooms.GetComponent<Text>().CrossFadeAlpha(0, .5f, false);
            
        }
    }
}
