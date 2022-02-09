using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMushroom : MonoBehaviour
{
    public static int scoreOfMushrooms = 0; //���������� ��� �������� ���������� ���������
    public GameObject scoreMushrooms; //������ � ������� ������ ������� ������ �� ��� ������� 

    private void CountScore()
    {
        scoreOfMushrooms++; // ������� ���������� ������
        scoreMushrooms.GetComponent<Text>().text = scoreOfMushrooms.ToString(); // ����������� � ����� ���������� scoreOfMushrooms ��� ������ ���������� ��������� ���������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mushrooms")
        {
            CountScore();
        }
    }

}
