using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_manager : MonoBehaviour
{
	GameObject newScoreObject;
	GameObject hightScoreObject;
	public GameObject currentScoreObject;
	public MainMenu menu;
	public int highScore = 0;
	public int newScore = 0;

	void Start()
	{
		LoadScores();
		newScoreObject = GameObject.FindGameObjectWithTag("newScore");
		hightScoreObject = GameObject.FindGameObjectWithTag("highScore");
		//currentScoreObject = GameObject.FindGameObjectWithTag("currentScore");
		newScoreObject.GetComponent<Text>().text = newScore.ToString();
		hightScoreObject.GetComponent<Text>().text = highScore.ToString();
	}
	public void OnEndOfGame()
	{

		if (newScore > highScore) {
			highScore = newScore;
		}
		SaveScores();
		menu.ActivateGameOverScreen();

	}

	internal void updateScore(int v)
	{
		newScore += v;
		currentScoreObject.GetComponent<Text>().text = newScore.ToString();
	}

	void SaveScores()
    {
		PlayerPrefs.SetInt("newScore", newScore);
		PlayerPrefs.SetInt("highScore", highScore);
	}

	void LoadScores()
    {
		newScore = PlayerPrefs.GetInt("newScore");
		highScore = PlayerPrefs.GetInt("highScore");

	}
}
