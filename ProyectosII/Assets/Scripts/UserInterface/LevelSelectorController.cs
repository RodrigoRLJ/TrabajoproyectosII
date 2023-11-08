using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorController : MonoBehaviour


{
    public void ReturnMainMenu()
    {
        GameManager.ChangeScene("MainMenu");
    }

    public void GoToLevel1()
    {
        GameManager.ChangeScene("Level1");
    }

    public void GoToLevel2()
    {
        GameManager.ChangeScene("Level2");
    }

    public void GoToLevel3()
    {
        GameManager.ChangeScene("Level3");
    }

    public void GoToLevel4()
    {
        GameManager.ChangeScene("Level4");
    }
}