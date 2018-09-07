﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	AudioSource audioSource;
	
	[Header("Music Clips")]
	[SerializeField] AudioClip menuMusicIntro;
	[SerializeField] AudioClip menuMusicMainLoop;
	[SerializeField] AudioClip stageIntroMusic;
	[SerializeField] AudioClip stageMainLoop;
	[SerializeField][Tooltip("Death Intro Clip")] AudioClip stageDeathIntroClip;
	[SerializeField] AudioClip stageDeathLoopClip;
	public float minVolInMenu;
	public float maxVol;
	// [SerializeField] AudioClip stageVictoryClip; // this one is for much later. i don't want to add a random victory condition yet justr for the sake of completing the game before i even know what it's about.
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
		// audioSource.clip = menuMusicIntro;
		StartMenuMusic();
	}
	
	
	void Update () {
		
	}

	// Turn music on and off
	
	public void StartMenuMusic()
	{
		CancelInvoke();
		audioSource.clip = menuMusicIntro;
		audioSource.loop = false;
		audioSource.Play();
		Invoke("StartMainMenuMainLoop", menuMusicIntro.length);
	}
	public void StartStageMusic()
	{
		CancelInvoke();
		audioSource.clip = stageIntroMusic;
		audioSource.Play();
		audioSource.loop = false;
		 // start the main stage loop once the introclip is done
		Invoke("StartMainStageLoop", stageIntroMusic.length); // AudioClip.length = The length in seconds of the clip
	}
	public void StartDeathMusic()
	{
		CancelInvoke();
		audioSource.clip = stageDeathIntroClip;
		// audioSource.loop = false;
		audioSource.Play();
		StartCoroutine(StartDeathLoop());
		// Invoke("StartDeathLoop", stageDeathIntroClip.length);
	}
	void StartMainMenuMainLoop()
	{
		audioSource.clip = menuMusicMainLoop;
		audioSource.Play();
		audioSource.loop = true;
	}
	
	void StartMainStageLoop()
	{
		audioSource.clip = stageMainLoop;
		audioSource.Play();
		audioSource.loop = true;
	}

	// public void MusicTransition()
	// {
	// 	// reduce volume to zero. Change clip. Increase volume to max again.
	// }

	public void AdjustVol(float newVol)
	{
		audioSource.volume = newVol * 0.9f;
		maxVol = 0.9f * newVol;
		minVolInMenu = 0.4f * newVol;
	}
	// =------------------------- Single Line Functions -----------------------= //


	public void GamePausedMusicVolDown() {StartCoroutine(SlowlyReduceVolume());}
	public void GameUnPausedMusicVolUp() {StartCoroutine(SlowlyIncreaseVolume());}
	public void TurnOffMusic(){audioSource.enabled = false;}
	public void TurnOnMusic(){audioSource.enabled = true;}

	// =------------------------- Single Line Functions -----------------------= //

	// =------------------------- Coroutines ------------------------------= //

	IEnumerator SlowlyReduceVolume()
	{
		while (audioSource.volume >= minVolInMenu)
		{
			audioSource.volume -= 0.05f;
			yield return new WaitForSecondsRealtime(0.01f);
			// yield return new WaitForSeconds(Time.deltaTime);
		}
		yield return null;
	}
	IEnumerator SlowlyIncreaseVolume()
	{
		while (audioSource.volume <= maxVol)
		{
			audioSource.volume += 0.05f;
			yield return new WaitForSecondsRealtime(0.01f);
		}
		yield return null;
	}
	IEnumerator StartDeathLoop()
	{
		yield return new WaitForSecondsRealtime(stageDeathIntroClip.length);
		audioSource.clip = stageDeathLoopClip;
		audioSource.Play();
		audioSource.loop = true;
		yield return null;
	}
	IEnumerator MusicTransition(AudioClip newClip)
	{
		// first we adjust the music down to zero. 
		while (audioSource.volume > 0f)
		{
			audioSource.volume -= 0.05f;
			yield return new WaitForSecondsRealtime(0.01f);
		}
		// change audio clip.
		audioSource.clip = newClip;
		audioSource.Play();
		while (audioSource.volume < maxVol)
		{
			audioSource.volume += 0.05f;
			yield return new WaitForSecondsRealtime(0.01f);
		}
		yield return null;
	}

	// =------------------------- Coroutines ------------------------------= //
}
