using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject loseMenu;
    [SerializeField] public GameObject pauseButton;

    public static bool isPaused; //���������� ��� �������� ���������� �� ���� �� �����, ���������� � ������ Hero ����� ��������� ��� ��������� ���� ���� �� �����

    
    private void Update()
    {
        if (Hero.health < 1) // ��� ������� �������� ��������� ������ 1 �������� ���� ��������� � ��������� ������ ���� �����
        { 
            loseMenu.SetActive(true);
            pauseButton.SetActive(false);
        }
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //�������� ������ � �������� ����� � ������������� ��
        Time.timeScale = 1f;
        isPaused = false;
        ScoreMushroom.scoreOfMushrooms = 0;
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("Menu"); //��������� �� ������� ����
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit(); //��������� ��������� ����
        Debug.Log("�� ��������� ����� �� ����");
    }
}
