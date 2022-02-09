using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsSelector : MonoBehaviour
{
    public Button[] levels;

    public static int lastLevel;

    
    //private void Start()
    //{
    //    int levelReached = PlayerPrefs.GetInt("level Reached", 3);

    //    for (int i = 0; i < levels.Length; i++)
    //        if (i + 1 > levelReached)
    //            levels[i].interactable = false;
    //}

    public void Select(int numberInBuild)
    {
        SceneManager.LoadScene(numberInBuild);
    }

    public void Exit()
    {
        Debug.Log("Мы вышли из игры!");
        Application.Quit();
    }

    public void PlayButton()
    {
        lastLevel = LvlButton.countUnlockLevel + 1;
        SceneManager.LoadScene(lastLevel);
    }

}
