using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(false);
    }

    public void Play()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    public void GameOverToMenu()
    {
        menu.SetActive(true);
        gameOver.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            menu.SetActive(true);
        }
    }
}
