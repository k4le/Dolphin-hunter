using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_oxygen : MonoBehaviour
{
    GameObject gameController;
    public float oxygen = 100.0f;
    float max_oxygen;
    [SerializeField] float oxygen_consumption = 15;
    [SerializeField] float oxygenRegen = 50;
    Slider slider;
    Image bubbles;
    
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        slider = GameObject.Find("OxygenBar").GetComponent<Slider>();
        bubbles = GameObject.Find("OxygenBubbles").GetComponent<Image>();
        oxygen = 100.0f;
        max_oxygen = oxygen;
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
            oxygen += oxygenRegen * Time.deltaTime;
            if (oxygen > max_oxygen)
            {
                oxygen = max_oxygen;
            }
        }

        slider.value = oxygen;
        bubbles.fillAmount = oxygen / max_oxygen;

        if (oxygen <= 0)
        {
            gameController.GetComponent<Game_manager>().OnEndOfGame();
        }
    }

}
