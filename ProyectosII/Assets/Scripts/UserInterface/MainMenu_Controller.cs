using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Controller : MonoBehaviour
{
    public void GoToLevelSelector()
    {
        GameManager.ChangeScene("LevelSelector");
    }

    public void GoToEnciclopedia()
    {
        GameManager.ChangeScene("Enciclopedia");
    }

    public void GoToCredits()
    {
        GameManager.ChangeScene("Credits");
    }
}