using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMushroom : MonoBehaviour
{
    public static int scoreOfMushrooms = 0; //переменная для подсчета количества грибочков
    public GameObject scoreMushrooms; //панель с выводом текста сколько грибов мы уже собрали 

    private void CountScore()
    {
        scoreOfMushrooms++; // плюсуем количество грибов
        scoreMushrooms.GetComponent<Text>().text = scoreOfMushrooms.ToString(); // присваиваем в текст переменную scoreOfMushrooms для вывода количества грибочков собранных
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mushrooms")
        {
            CountScore();
        }
    }

}
