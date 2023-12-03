using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndScript : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.ChangeScene(nextLevelName);
    }
}
