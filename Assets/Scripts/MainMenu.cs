using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;

    public GameObject gameOver;

    GameObject gameManager;
    public Canvas hud;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        Time.timeScale = 0f;
        gameOver.SetActive(false);
        hud.enabled = false;

    }

    public void Play()
    {
        Time.timeScale = 1f;
        GameObject.Find("MusicManager").GetComponent<MusicManager>().playMusic("GameMusic1");
        menu.SetActive(false);
        gameManager.GetComponent<Game_manager>().newScore = 0;
        hud.enabled = true;
    }
    public void ActivateGameOverScreen()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }
    public void GameOverToMenu()
    {
        //Restart game when player press button
        Application.LoadLevel(Application.loadedLevel);
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
