using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_manager : MonoBehaviour
{
	GameObject newScoreObject;
	GameObject hightScoreObject;

	public int highScore = 0;
	public int newScore = 0;

	void Start()
	{

		newScoreObject = GameObject.FindGameObjectWithTag("newScore");
		hightScoreObject = GameObject.FindGameObjectWithTag("highScore");
	}
	public void OnEndOfGame()
	{
		newScoreObject.GetComponent<Text>().text = newScore.ToString();
		if (newScore > highScore) {
			highScore = newScore;
			hightScoreObject.GetComponent<Text>().text = newScore.ToString();
		}
		// Application.LoadLevel(Application.loadedLevel);
		newScoreObject.GetComponent<Text>().text = "0";
		newScore = 0;
	}

	internal void updateScore(int v)
	{
		newScore += v;
		Debug.Log(newScore);
	}
}
