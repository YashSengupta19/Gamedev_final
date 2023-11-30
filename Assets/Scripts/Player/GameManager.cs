using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public PlayerHealth PH;

    public void GameOver()
{
    if (PH.slider.value == 0)
    {
        OnPlayerDeath?.Invoke();
    }
}

    void Update()
    {
        GameOver();
    }


}