using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject loseMenu;
    [SerializeField] public GameObject pauseButton;

    public static bool isPaused; //переменная для проверки поставлена ли игра на паузу, используем в классе Hero чтобы запретить ему двигаться если игра на паузе

    
    private void Update()
    {
        if (Hero.health < 1) // при условии здоровья персонажа меньше 1 включаем меню проигрыша и отключаем кнопку меню паузы
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //получаем доступ к активной сцене и перезапускаем ее
        Time.timeScale = 1f;
        isPaused = false;
        ScoreMushroom.scoreOfMushrooms = 0;
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("Menu"); //переходим на главное меню
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit(); //закрываем полностью игру
        Debug.Log("мы полностью вышли из игры");
    }
}
