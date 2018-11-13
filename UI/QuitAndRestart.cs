using System.Collections;
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
	public bool mouseOverMenu = true;

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
				if (mouseOverMenu == false)
				{
					if (Input.GetMouseButtonDown(0))
						UnPauseGame();
				}
			}
	}
	// The quit game function returns the player to the main menu and cleanses the scene of all leftover items that need to be cleaned up.
	// Will likely need to keep editing this in the future
	public void QuitGame() // TODO: clean up this code and comment it maybe
	{
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
		Arrow[] allArrows = FindObjectsOfType<Arrow>();
		foreach(Arrow x in allArrows)
			x.gameObject.SetActive(false);
		FindObjectOfType<TowerPlacingScript>().towerModel = null;
		FindObjectOfType<TowerPlacingScript>().towerPrefab = null;
		FindObjectOfType<TowerPlacingScript>().towerSelected = false;
		// Time.timeScale = 0f; // Temporary. needs to be replaced. actually dont nee

		// musicManager.GameUnPausedMusicVolUp(); // put the music volume back up
		musicManager.StartMenuMusic();
		musicManager.ReduceMusicVolWhenPaused(false);
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
		FindObjectOfType<TowerPlacingScript>().towerModel = null;
		FindObjectOfType<TowerPlacingScript>().towerPrefab = null;
		FindObjectOfType<TowerPlacingScript>().towerSelected = false;
		FindObjectOfType<TowerPlacingScript>().towerUIAbleToBeSummoned = true;
		BeeScript[] allBees = FindObjectsOfType<BeeScript>();
		foreach(BeeScript x in allBees)
			x.gameObject.SetActive(false);
		resumeButton.interactable = true;
		musicManager.ReduceMusicVolWhenPaused(false);
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
		FindObjectOfType<TowerPlacingScript>().towerUIAbleToBeSummoned = false;
		musicManager.ReduceMusicVolWhenPaused(true);
		playerHasLost = hasPlayerLost;
		gamePaused = true;
		pauseMenuUI.SetActive(true);
		
		Time.timeScale = 0f;

	}
	public void UnPauseGame()
	{
		
		if (playerHasLost == true)
			return;
		musicManager.ReduceMusicVolWhenPaused(false);
		gamePaused = false;
		Time.timeScale = 1f;
		pauseMenuUI.SetActive(false);
		AreYouSureQuitUI.SetActive(false);
		AreYouSureRestartUI.SetActive(false);
		// musicManager.GameUnPausedMusicVolUp();
		FindObjectOfType<TowerPlacingScript>().towerUIAbleToBeSummoned = true;
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
		// UnPauseGame();
		pauseMenuUI.SetActive(true);
	}
}
