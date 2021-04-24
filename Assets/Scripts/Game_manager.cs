using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    private int score;

    private void Start()
    {
        score = 0;
    }

    public void addScore(int amount)
    {
        score += amount;
    }

    public void OnEndOfGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
