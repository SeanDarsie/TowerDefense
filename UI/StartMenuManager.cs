using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// COMMENT: It may be in my best interest to have a class that handles switching between menus so i don't have problems with a class disabling it's own gameobject
// This class is currently fulfilling part of that role, but only for starting the game. I mean something more specific like switching between main and options menu.
// I think i will make a class that simply turns on gameobjects with a switch statement that takes a string.

public class StartMenuManager : MonoBehaviour {
	[SerializeField] GameObject startMenuUI;
	[SerializeField] GameObject[] allCameras;
	[SerializeField] GameObject[] allCreepspawners;
	[SerializeField] GameObject[] allTowers;
	[SerializeField] Button resumeButton;
	PlayerStats playerStats;
	MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
		playerStats = FindObjectOfType<PlayerStats>();
		musicManager = FindObjectOfType<MusicManager>();
		startMenuUI.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 public void StartGame()
	 {
		int whatLevelIsIt = FindObjectOfType<LevelChooser>().chosenLevel;
		Time.timeScale = 1.0f;
		startMenuUI.SetActive(false);
		playerStats.ResetLevelHealthAndMonies();
		musicManager.StartStageMusic();

		//Set all cameras to inactive before choosing the correct camera.
		foreach (GameObject x in allCameras)
			x.SetActive(false);
		allCameras[whatLevelIsIt].SetActive(true); 

		// Set all the towers to inactive and then set the current levels tower to active
		foreach (GameObject x in allTowers)
			x.SetActive(false);
		allTowers[whatLevelIsIt].SetActive(true);

		// set all creepspawners to inactive and isactive to false so they don't spawn minions
		foreach (GameObject creepSpawner in allCreepspawners)
		{
			creepSpawner.GetComponent<CreepSpawner>().isActive = false;
			creepSpawner.SetActive(false);
		}
		allCreepspawners[whatLevelIsIt].SetActive(true);

		allCreepspawners[whatLevelIsIt].GetComponent<CreepSpawner>().isActive = true;
		allCreepspawners[whatLevelIsIt].GetComponent<CreepSpawner>().canSendWave = true;
		FindObjectOfType<QuitAndRestart>().playerHasLost = false;
		resumeButton.interactable = true;
		
	 }
}
