﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public static AudioClip GameMusic1, GameMusic2, MainMenuMusic;
	static AudioSource audioSrc;

	// Start is called before the first frame update
	void Awake()
	{
		MainMenuMusic = Resources.Load<AudioClip>("blue_world_proud_music_preview");
		GameMusic2 = Resources.Load<AudioClip>("Subverting_the_Water_Level");
		GameMusic1 = Resources.Load<AudioClip>("information_age_proud_music");
		audioSrc = GetComponent<AudioSource>();
	}

	public void playMusic(string clip)
	{
		Debug.Log("asdf");
		audioSrc.volume = 0.07f;
		switch (clip) {
			case "GameMusic1":
				audioSrc.clip = GameMusic1;
				audioSrc.Play();
				break;
			case "GameMusic2":
				audioSrc.clip = GameMusic2;
				audioSrc.Play();
				break;
			case "MenuBackgroundMusic":
				audioSrc.clip = MainMenuMusic;
				audioSrc.Play();
				break;
		}
	}
	public IEnumerator StartFade(float duration, float targetVolume)
	{
		float currentTime = 0;
		float start = audioSrc.volume;

		while (currentTime < duration) {
			currentTime += Time.deltaTime;
			audioSrc.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
			yield return null;
		}
		yield break;
	}
	public IEnumerator fade()
	{
		StartCoroutine(StartFade(0.2f, audioSrc.volume / 4));
		yield return new WaitForSeconds(0.2f);
	}

	public void endMusic()
	{
		StartCoroutine(fade());
	}
}
