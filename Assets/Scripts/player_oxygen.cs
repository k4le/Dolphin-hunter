using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_oxygen : MonoBehaviour
{
    GameObject gameController;
    public float oxygen = 100.0f;
    [SerializeField] float oxygen_consumption = 15;
    Slider slider;
    
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        slider = GameObject.Find("OxygenBar").GetComponent<Slider>();
        oxygen = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            oxygen -= oxygen_consumption * Time.deltaTime;
        }
        else
        {
            oxygen = 100;
        }

        slider.value = oxygen;

        if (oxygen <= 0)
        {
            gameController.GetComponent<Game_manager>().OnEndOfGame();
        }
    }

}
