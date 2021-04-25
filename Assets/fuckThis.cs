using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuckThis : MonoBehaviour
{
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = gameManager.GetComponent<Game_manager>().newScore.ToString();
    }
}
