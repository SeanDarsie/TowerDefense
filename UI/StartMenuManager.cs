using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour {
	[SerializeField] GameObject startMenuUI;
	[SerializeField] GameObject[] allCameras;
	[SerializeField] GameObject[] allCreepspawners;
	[SerializeField] GameObject[] allTowers;
	PlayerStats playerStats;
	MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
		playerStats = FindObjectOfType<PlayerStats>();
		musicManager = FindObjectOfType<MusicManager>();
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
	
		// each tower has a creepspawner. A CameraHolder. What else??? 

		//  switch(FindObjectOfType<LevelChooser>().chosenLevel)
		//  {
			 
		// 	 case 0:
		// 	 	// start the first level. For now we're just going to set Time.timeScale to 1 and turn off the start menu.
		// 		 // in future we will have a more complex level system.
		// 		Time.timeScale = 1.0f;
		// 		startMenuUI.SetActive(false);
		// 		playerStats.ResetLevelHealthAndMonies();
								
		// 		//Set all cameras to inactive before choosing the correct camera.
		// 		foreach (GameObject x in allCameras)
		// 			x.SetActive(false);
		// 		allCameras[whatLevelIsIt].SetActive(true); // first set all cameras to inactive


		// 		// set all creepspawners to inactive and isactive to false so they don't spawn minions
		// 		foreach (GameObject creepSpawner in allCreepspawners)
		// 		{
		// 			creepSpawner.GetComponent<CreepSpawner>().isActive = false;
		// 			creepSpawner.SetActive(false);
		// 		}
		// 		allCreepspawners[whatLevelIsIt].SetActive(true);
		// 		allCreepspawners[whatLevelIsIt].GetComponent<CreepSpawner>().isActive = true;
		// 		// each tower has a creepspawner. A CameraHolder. What else??? 
		// 		break;
		// 	case 1:
		// 		break;
		// 	case 2:
		// 		break;
		// 	case 3:
		// 		break;
		// 	case 4:
		// 		break;
		// 	case 5:
		// 		break;
		// 	case 6:
		// 		break;
		// 	case 7:
		// 		break;
		// 	default:
		// 		break;
		//  }
	 }
}
