﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuitAndRestart : MonoBehaviour {
    [SerializeField] private GameObject pauseMenuUI;
	[SerializeField] GameObject AreYouSureQuitUI;
	[SerializeField] GameObject AreYouSureRestartUI;
	[SerializeField] GameObject startMenu;
	[SerializeField] Button resumeButton;
	[SerializeField] CreepSpawner[] currentLevelsCreepspawner;
	MusicManager musicManager;
	
	[HideInInspector]
	public bool playerHasLost = false;
	
    private bool gamePaused = false;

    // Use this for initialization
    void Start () {
		musicManager = FindObjectOfType<MusicManager>();
		pauseMenuUI.SetActive(false);
		AreYouSureQuitUI.SetActive(false);
		AreYouSureRestartUI.SetActive(false);
		currentLevelsCreepspawner = FindObjectsOfType<CreepSpawner>();
		UnPauseGame();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gamePaused == false)
				PauseGame(playerHasLost);
			else
				UnPauseGame();
		}
		if (gamePaused == true)
			{
				// if we click off the ui i want to unpause the game
				if (Input.GetMouseButtonDown(0))
				{
					// raycast to see if we hit some of the menu??
				}
			}
	}

	public void QuitGame()
	{
		// Application.Quit(); Now handled elseWhere
		// activate main menu. Reset Level(x);

		// Debug.Log("Whay are you restarting the game");
	

		// bring up start menu
		startMenu.SetActive(true);

		// close quit ui
		AreYouSureQuitUI.SetActive(false);

		// reset Waves
		foreach(CreepSpawner x in currentLevelsCreepspawner)
			x.SetWave(0);
		FindObjectOfType<CreepManager>().DestroyAllActiveCreeps();
		// FindObjectOfType<StartMenuManager>().StartGame();
		FindObjectOfType<PlayerStats>().ResetLevelHealthAndMonies();
		FindObjectOfType<TowerManager>().DestroyAllTowers();
		BeeScript[] allBees = FindObjectsOfType<BeeScript>();
		foreach(BeeScript x in allBees)
			x.gameObject.SetActive(false);
		// Time.timeScale = 0f; // Temporary. needs to be replaced. actually dont nee

		// musicManager.GameUnPausedMusicVolUp(); // put the music volume back up
		musicManager.StartMenuMusic();
	}

	public void RestartLevel() // restart current level. 
	{
	
		AreYouSureRestartUI.SetActive(false);
		foreach(CreepSpawner x in currentLevelsCreepspawner)
			x.SetWave(0); // for this i could simply chalge all the waves of all the creep spawners 
		// also need to destroy all creeps in the level.
		FindObjectOfType<CreepManager>().DestroyAllActiveCreeps();
		FindObjectOfType<StartMenuManager>().StartGame();
		FindObjectOfType<PlayerStats>().ResetLevelHealthAndMonies();
		FindObjectOfType<TowerManager>().DestroyAllTowers();
		BeeScript[] allBees = FindObjectsOfType<BeeScript>();
		foreach(BeeScript x in allBees)
			x.gameObject.SetActive(false);
		resumeButton.interactable = true;
	}

	public void PauseGame(bool hasPlayerLost)
	{	
		if (hasPlayerLost == true)
			{
				musicManager.StartDeathMusic();
				resumeButton.interactable = false; // make interactible in the start game function i suppoose
			}
		// else
		// 	musicManager.GamePausedMusicVolDown();
		playerHasLost = hasPlayerLost;
		gamePaused = true;
		pauseMenuUI.SetActive(true);
		
		Time.timeScale = 0f;

	}
	public void UnPauseGame()
	{
		if (playerHasLost == true)
			return;
		gamePaused = false;
		Time.timeScale = 1f;
		pauseMenuUI.SetActive(false);
		AreYouSureQuitUI.SetActive(false);
		AreYouSureRestartUI.SetActive(false);
		musicManager.GameUnPausedMusicVolUp();
	}
	public void AreYouSureQuit()
	{
		// Debug.Log("AARRRR YE SURE Quit");
		AreYouSureQuitUI.SetActive(true);
		pauseMenuUI.SetActive(false);
	}
	public void AreYouSureRestart()
	{
		// Debug.Log ("Are you sure you want to restart");
		AreYouSureRestartUI.SetActive(true);
		pauseMenuUI.SetActive(false);
	}
	public void No()
	{
		AreYouSureQuitUI.SetActive(false);
		AreYouSureRestartUI.SetActive(false);
		UnPauseGame();
	}
}
