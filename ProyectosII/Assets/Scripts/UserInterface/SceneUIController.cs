using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUIController : MonoBehaviour
{
    public void ReturnMainMenu()
    {
        GameManager.ChangeScene(SceneRecords.MAIN_MENU_SCREEN);
    }

    public void GoToLevel1()
    {
        GameManager.ChangeScene(SceneRecords.LEVEL_1);
    }

    public void GoToLevel2()
    {
        GameManager.ChangeScene(SceneRecords.LEVEL_2);
    }

    public void GoToLevel3()
    {
        GameManager.ChangeScene(SceneRecords.LEVEL_3);
    }

    public void GoToLevel4()
    {
        GameManager.ChangeScene(SceneRecords.LEVEL_4);
    }

    public void GoToLevelSelector()
    {
        GameManager.ChangeScene(SceneRecords.LEVE_SELECTOR_SCREEN);
    }

    public void GoToEnciclopedia()
    {
        GameManager.ChangeScene(SceneRecords.ENCICLOPEDIA_SCREEN);
    }

    public void GoToCredits()
    {
        GameManager.ChangeScene(SceneRecords.CREDITS_SCREEN);
    }
}