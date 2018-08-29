using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuitAndRestart : MonoBehaviour {
    [SerializeField] private GameObject pauseMenuUI;
	[SerializeField] GameObject AreYouSureQuitUI;
	[SerializeField] GameObject AreYouSureRestartUI;
	[SerializeField] GameObject startMeuUI;
	[SerializeField] CreepSpawner currentLevelsCreepspawner;
	bool playerHasLost = false;
	
    private bool gamePaused = false;

    // Use this for initialization
    void Start () {
		pauseMenuUI.SetActive(false);
		AreYouSureQuitUI.SetActive(false);
		AreYouSureRestartUI.SetActive(false);
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
	}

	public void QuitGame()
	{
		// Application.Quit(); Now handled elseWhere
		// activate main menu. Reset Level(x);


		Time.timeScale = 0f; // Temporary. needs to be replaced

		// bring up start menu
		startMeuUI.SetActive(true);

		// close quit ui
		AreYouSureQuitUI.SetActive(false);

		// reset Waves
		currentLevelsCreepspawner.SetWave(0);
		FindObjectOfType<CreepManager>().DestroyAllActiveCreeps();
		// FindObjectOfType<StartMenuManager>().StartGame();
		FindObjectOfType<PlayerStats>().ResetLevelHealthAndMonies();
		FindObjectOfType<TowerManager>().DestroyAllTowers();
	}

	public void RestartLevel()
	{
		// 2 choices. Reload scene, or write a reset function in the level manager. i think i'm going to do the first one for now but i should put this on the TODO list
		// TODO: write a reset function in the level manager. 
		// Debug.Log("TODO: Implement a level reset function in the level manager!");
		// SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		AreYouSureRestartUI.SetActive(false);
		currentLevelsCreepspawner.SetWave(0);
		// also need to destroy all creeps in the level.
		FindObjectOfType<CreepManager>().DestroyAllActiveCreeps();
		FindObjectOfType<StartMenuManager>().StartGame();
		FindObjectOfType<PlayerStats>().ResetLevelHealthAndMonies();
		FindObjectOfType<TowerManager>().DestroyAllTowers();
	}

	public void PauseGame(bool hasPlayerLost)
	{	
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
